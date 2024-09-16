using Template.Domain.Abstract.Persistence;
using Template.Domain.Components.Customers.Persistence;

namespace Template.Persistence.Abstract;

internal sealed class UnitOfWork : IUnitOfWork
{
    public UnitOfWork( ICustomerRepository customers )
    {
        Customers = customers;
    }

    public ICustomerRepository Customers { get; }
}
