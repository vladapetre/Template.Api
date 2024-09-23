using Template.Domain.Components.Customers.Persistence;

namespace Template.Domain.Abstract.Persistence;

public interface IUnitOfWork
{
    ICustomerRepository Customers { get; }

    public Task SaveChangesAsync( CancellationToken cancellationToken = default );
}
