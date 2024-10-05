using Template.Domain.Components.Customers.Models;

namespace Template.Domain.Components.Customers.Persistence;

public interface ICustomerRepository
{
    public Task<Customer> AddAsync( Customer customer );
}
