using Template.Core.Types;
using Template.Domain.Components.Customers;
using Template.Domain.Components.Customers.Persistence;
using Template.Persistence.Context;

namespace Template.Persistence.Components.Customers;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext databaseContext;

    public CustomerRepository( DatabaseContext databaseContext )
    {
        this.databaseContext = databaseContext;
    }

    public async Task<Result<Customer>> AddAsync( Customer customer )
    {
        await databaseContext.AddAsync(customer);
        await databaseContext.SaveChangesAsync();

        return customer;
    }
}
