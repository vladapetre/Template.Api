using Template.Application.Abstract;
using Template.Core.Types;
using Template.Domain.Entities;

namespace Template.Application.Components.Customers.CreateCustomer;

public interface ICreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Option<Customer>> { }

public sealed class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
{
    public async Task<Option<Customer>> HandlerAsync( CreateCustomerCommand request )
    {
        var customer = Customer.Create(request.Name);

        return customer;
    }
}
