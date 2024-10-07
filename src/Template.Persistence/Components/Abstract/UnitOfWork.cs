using Template.Application.Components.Abstract.Persistence;
using Template.Application.Components.Customers.Persistence;
using Template.Core.Extensions;
using Template.Core.Primitives;
using Template.Persistence.Context;

namespace Template.Persistence.Components.Abstract;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext context;
    private readonly IEventPublisher eventPublisher;

    public UnitOfWork( DatabaseContext context, IEventPublisher eventPublisher, ICustomerRepository customers )
    {
        this.context = context;
        this.eventPublisher = eventPublisher;
        Customers = customers;
    }

    public ICustomerRepository Customers { get; }

    public async Task SaveChangesAsync( CancellationToken cancellationToken = default )
    {
        var entities = context.ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .ToList();

        await entities
            .SelectMany(entity => entity.Events)
            .ExecuteAsync(eventPublisher.PublishAsync);

        entities.Execute(entity => entity.ClearEvents());

        await context.SaveChangesAsync(cancellationToken);
    }
}
