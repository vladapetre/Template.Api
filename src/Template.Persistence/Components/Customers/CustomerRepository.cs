using Template.Application.Components.Customers.Persistence;
using Template.Domain.Components.Customers.Models;
using Template.Persistence.Context;

namespace Template.Persistence.Components.Customers;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseDbContext databaseDbContext;

    public CustomerRepository( DatabaseDbContext databaseDbContext )
    {
        this.databaseDbContext = databaseDbContext;
    }

    public async Task<Customer> AddAsync( Customer customer )
    {
        await databaseDbContext.AddAsync(customer);

        return customer;
    }
}
