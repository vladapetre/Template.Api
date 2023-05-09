using Microsoft.EntityFrameworkCore.Diagnostics;
using Template.Domain.Primitives;

namespace Template.Persistence.Contexts.Interceptors;
internal sealed class RaiseEntityEventsSaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IEventBus _eventBus;

    public RaiseEntityEventsSaveChangesInterceptor(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
    DbContextEventData eventData,
    InterceptionResult<int> result,
    CancellationToken cancellationToken = default) => RaiseDomainEvents(eventData, result, cancellationToken);

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result) => RaiseDomainEvents(eventData, result).GetAwaiter().GetResult();

    private async ValueTask<InterceptionResult<int>> RaiseDomainEvents(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;

        if (dbContext is null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var entries = dbContext.ChangeTracker
           .Entries<IEntity>()
           .Where(x => x.Entity.Events != null && x.Entity.Events.Any());

        var events = entries
            .SelectMany(x => x.Entity.Events)
            .ToList();

        foreach (var entry in entries)
        {
            entry.Entity.ClearEvents();
        }

        foreach (var @event in events)
        {
            await _eventBus.DispatchAsync(@event);
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

}
