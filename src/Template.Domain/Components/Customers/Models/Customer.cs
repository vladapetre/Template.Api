using Template.Core.Exceptions;
using Template.Core.Primitives;

namespace Template.Domain.Components.Customers.Models;

public sealed record class Customer : AggregateRoot
{
    public CustomerId Id { get; private init; } = null!;
    public ApiKey ApiKey { get; private init; } = null!;
    public Subscription Subscription { get; private init; } = null!;
    public CustomerInformation Information { get; private init; } = null!;

    private Customer() { }

    private Customer( Subscription subscription, CustomerInformation information )
    {
        Id ??= CustomerId.Create();
        ApiKey ??= ApiKey.Create();
        Subscription = subscription;
        Information = information;
    }

    public static Customer? Create( string name )
        => name switch
        {
            { Length: > 0 } => new Customer(new TrialSubscription(), new CustomerInformation(name)), // does not handle whitespace
            _ => throw new CoreException(ExceptionCode.BadRequest($$"""Cannot create customer. Invalid parameter name : {{{name}}}""")) //
        };
}
