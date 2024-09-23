using Template.Core.Types;

namespace Template.Domain.Components.Customers.Persistence;

public interface ICustomerRepository
{
    public Task<Result<Customer>> AddAsync( Customer customer );
}
