using Template.Application.Components.Customers.Persistence;

namespace Template.Application.Components.Abstract.Persistence;

public interface IUnitOfWork
{
    ICustomerRepository Customers { get; }

    public Task SaveChangesAsync( CancellationToken cancellationToken = default );
}
