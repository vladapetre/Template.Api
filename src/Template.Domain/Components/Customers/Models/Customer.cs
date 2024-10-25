using Template.Core.Exceptions;
using Template.Core.Primitives;
using Template.Domain.Components.Customers.Events;

namespace Template.Domain.Components.Customers.Models;

public sealed record class Customer : AggregateRoot
{
    public CustomerId Id { get; private init; } 
    public ApiKey ApiKey { get; private init; } 
    public Subscription Subscription { get; private init; } 
    public CustomerInformation Information { get; private init; } 

    private Customer(  )
    {
    }

    private Customer( Subscription subscription, CustomerInformation information)
    {
        Id ??= CustomerId.Create();
        ApiKey ??= ApiKey.Create();
        Subscription = subscription;
        Information = information;
        
        RaiseEvent(new CustomerCreatedEvent(Id));
    }

    public static Customer? Create( string name )
        => name switch
        {
            { Length: > 0 } => new Customer(new TrialSubscription(), new CustomerInformation(name)), // does not handle whitespace
            _ => throw new CoreException(ExceptionCode.BadRequest($$"""Cannot create customer. Invalid parameter name : {{{name}}}""")) //
        };
}
