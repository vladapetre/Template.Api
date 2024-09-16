using Template.Application.Abstract;

namespace Template.Application.Components.Customers.CreateCustomer;

public sealed record class CreateCustomerCommand( string Name ) : IRequest
{
}
