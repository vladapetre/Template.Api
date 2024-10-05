using Template.Application.Abstract.Requests;

namespace Template.Application.Components.Customers.Requests.CreateCustomer;

public sealed record class CreateCustomerCommand( string Name ) : IRequest
{
}
