using MassTransit;
using Template.Application.Components.Abstract.Persistence;
using Template.Application.Components.Customers.Persistence;
using Template.Core.Extensions;
using Template.Core.Primitives;
using Template.Transaction.Context;

namespace Template.Transaction.Components.Abstract;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext context;
    private readonly IPublishEndpoint publishEndpoint;

    public UnitOfWork( 
        DatabaseContext context,
        ICustomerRepository customers,
        IPublishEndpoint publishEndpoint)
    {
        this.context = context;
        this.publishEndpoint = publishEndpoint;
        Customers = customers;
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
            .ExecuteAsync( (e) =>  publishEndpoint.Publish(e, cancellationToken));

        entities.Execute(entity => entity.ClearEvents());

        await context.SaveChangesAsync(cancellationToken);
    }
}
