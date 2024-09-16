using System.ComponentModel.DataAnnotations;

namespace Template.Presentation.Components.Customers.CreateCustomer;

public sealed record class CreateCustomerRequest( [Required] string Name )
{
}
