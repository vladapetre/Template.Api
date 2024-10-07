using Template.Application.Components.Abstract.Persistence;
using Template.Application.Components.Abstract.Requests;
using Template.Core.Types;
using Template.Domain.Components.Customers.Models;

namespace Template.Application.Scenarios.CreateCustomer;

public interface ICreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer> { }

public sealed class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
{
    private readonly IUnitOfWork unitOfWork;

    public CreateCustomerCommandHandler( IUnitOfWork unitOfWork )
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Customer> HandleAsync( CreateCustomerCommand request )
    {
        var customer = await Customer.Create(request.Name)
            .ContinueAsync(unitOfWork.Customers.AddAsync);

        await unitOfWork.SaveChangesAsync();

        return customer.GetValueOrThrow(new NotImplementedException());
    }
}
