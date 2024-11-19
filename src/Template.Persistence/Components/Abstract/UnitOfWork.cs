using Template.Application.Components.Abstract.Persistence;
using Template.Application.Components.Customers.Persistence;
using Template.Core.Extensions;
using Template.Core.Primitives;
using Template.Transaction.Context;

namespace Template.Transaction.Components.Abstract;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext context;

    public UnitOfWork( 
        DatabaseContext context,
        ICustomerRepository customers)
    {
        this.context = context;
        this.Customers = customers;
    }

    public ICustomerRepository Customers { get; }

    public async Task SaveChangesAsync( CancellationToken cancellationToken = default )
    {
        var entities = context.ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .ToList();

        await  entities
            .SelectMany(entity => entity.Events)
            .ExecuteAsync( (e) =>  PublishEventAsync(e, cancellationToken));

        entities.Execute(entity => entity.ClearEvents());

        await context.SaveChangesAsync(cancellationToken);
    }

    private async Task PublishEventAsync<TEvent>( TEvent @event, CancellationToken cancellationToken ) where TEvent : class, IEvent  =>
        await Task.CompletedTask;
}
