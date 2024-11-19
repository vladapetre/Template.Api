using Template.Application.Components.Customers.Persistence;
using Template.Domain.Components.Customers.Models;
using Template.Transaction.Context;

namespace Template.Transaction.Components.Customers;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext databaseContext;

    public CustomerRepository( DatabaseContext databaseContext )
    {
        this.databaseContext = databaseContext;
    }

    public async Task<Customer> AddAsync( Customer customer )
    {
        await databaseContext.AddAsync(customer);

        return customer;
    }
}
