using Template.Application.Components.Abstract.Requests;

namespace Template.Application.Scenarios.CreateCustomer;

public sealed record class CreateCustomerCommand( string Name ) : IRequest
{
}
