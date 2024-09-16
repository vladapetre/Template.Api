using Template.Application.Abstract;
using Template.Core.Types;
using Template.Domain.Abstract.Persistence;
using Template.Domain.Components.Customers;

namespace Template.Application.Components.Customers.CreateCustomer;

public interface ICreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Option<Customer>> { }

public sealed class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
{
    private readonly IUnitOfWork unitOfWork;

    public CreateCustomerCommandHandler( IUnitOfWork unitOfWork )
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Option<Customer>> HandlerAsync( CreateCustomerCommand request )
    {
        var customer = Customer.Create(request.Name);

        return await unitOfWork.Customers.Insert(customer);
    }
}
