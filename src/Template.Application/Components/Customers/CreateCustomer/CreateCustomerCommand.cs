using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Abstract;

namespace Template.Application.Components.Customers.CreateCustomer;

public sealed record class CreateCustomerCommand(string Name) : IRequest
{
}
