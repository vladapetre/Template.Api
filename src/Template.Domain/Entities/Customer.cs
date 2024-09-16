using Template.Core.Primitives;

namespace Template.Domain.Entities;

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

    public static Customer Create( string name )
        => name switch
        {
            { Length: > 0 } => new(new TrialSubscription(), new CustomerInformation(name)), // does not handle whitespace
            _ => throw new ArgumentException("Cannot create customer.", nameof(name)),
        };
}
