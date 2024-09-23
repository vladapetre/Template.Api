using Template.Application.Abstract;
using Template.Core.Types;
using Template.Domain.Abstract.Persistence;
using Template.Domain.Components.Customers;

namespace Template.Application.Components.Customers.CreateCustomer;

public interface ICreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<Customer>> { }

public sealed class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
{
    private readonly IUnitOfWork unitOfWork;

    public CreateCustomerCommandHandler( IUnitOfWork unitOfWork )
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<Customer>> HandlerAsync( CreateCustomerCommand request )
    {
        var customer = await Customer.Create(request.Name)
            .ContinueAsync(unitOfWork.Customers.Insert);

        return customer;
    }


}
