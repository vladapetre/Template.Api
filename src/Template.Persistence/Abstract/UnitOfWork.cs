using Template.Domain.Abstract.Persistence;
using Template.Domain.Components.Customers.Persistence;
using Template.Persistence.Context;

namespace Template.Persistence.Abstract;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext context;

    public UnitOfWork( DatabaseContext context, ICustomerRepository customers )
    {
        this.context = context;
        Customers = customers;
    }

    public ICustomerRepository Customers { get; }

    public async Task SaveChangesAsync( CancellationToken cancellationToken = default ) => await context.SaveChangesAsync(cancellationToken);
}
