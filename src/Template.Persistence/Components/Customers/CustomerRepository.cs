using Template.Application.Components.Customers.Persistence;
using Template.Domain.Components.Customers.Models;
using Template.Transaction.Context;

namespace Template.Transaction.Components.Customers;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseDbContext databaseContext;

    public CustomerRepository( DatabaseDbContext databaseContext )
    {
        this.databaseContext = databaseContext;
    }

    public async Task<Customer> AddAsync( Customer customer )
    {
        await databaseContext.AddAsync(customer);

        return customer;
    }
}
