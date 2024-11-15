using System.Transactions;
using Template.Application.Components.Abstract.Persistence;
using Template.Application.Components.Customers.Persistence;
using Template.Core.Extensions;
using Template.Core.Primitives;
using Template.Persistence.Context;

namespace Template.Persistence.Components.Abstract;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseDbContext dbContext;
    private readonly IEventHandler eventHandler;

    public UnitOfWork( 
        DatabaseDbContext dbContext,
        IEventHandler eventHandler,
        ICustomerRepository customers)
    {
        this.dbContext = dbContext;
        this.eventHandler = eventHandler;
        Customers = customers;
    }

    public ICustomerRepository Customers { get; }

    public async Task SaveChangesAsync( CancellationToken cancellationToken = default )
    {
        var entities = dbContext.ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .ToList();

        await entities
            .SelectMany(entity => entity.Events)
            .ExecuteAsync(( e ) => PublishEventAsync(e, cancellationToken));

        entities.Execute(entity => entity.ClearEvents());

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private Task PublishEventAsync<TEvent>( TEvent @event, CancellationToken cancellationToken )
        where TEvent : IEvent => eventHandler.HandleAsync(@event, cancellationToken);
}
