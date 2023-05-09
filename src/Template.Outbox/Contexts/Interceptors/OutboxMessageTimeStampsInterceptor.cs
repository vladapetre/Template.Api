using Microsoft.EntityFrameworkCore.Diagnostics;
using Template.Outbox;
using Template.Outbox.Models;

namespace Template.Persistence.Contexts.Interceptors;
internal sealed class OutboxMessageTimeStampsInterceptor : SaveChangesInterceptor
{
    private readonly TimeProvider _timeProvider;

    public OutboxMessageTimeStampsInterceptor(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
    DbContextEventData eventData,
    InterceptionResult<int> result,
    CancellationToken cancellationToken = default) => UpdateTimeStamps(eventData, result, cancellationToken);

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result) => UpdateTimeStamps(eventData, result).GetAwaiter().GetResult();

    private async ValueTask<InterceptionResult<int>> UpdateTimeStamps(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;

        if (dbContext is null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var entries = dbContext.ChangeTracker
           .Entries<OutboxMessage>();


        foreach (var entry in entries)
        {
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                entry.Entity.CreatedOn = _timeProvider.UtcNow;
            }

            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                entry.Entity.ModifiedOn = _timeProvider.UtcNow;
            }
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

}
