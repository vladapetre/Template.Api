using Template.Core.Primitives;
using Template.Domain.Components.Customers.Models;

namespace Template.Domain.Components.Customers.Events;

public sealed record class CustomerCreatedEvent(CustomerId CustomerId) : IEvent
{
    
}