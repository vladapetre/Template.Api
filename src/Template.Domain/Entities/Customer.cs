using System.Text;

namespace Template.Domain.Entities;

public sealed record class Customer
{
    public CustomerId Id { get; private init; }
    public ApiKey Key { get; private init; }
    public Subscription Subscription { get; private init; }
    public CustomerInformation Information { get; private init; }

    private Customer(CustomerId id, ApiKey key, Subscription subscription, CustomerInformation information)
    {
        Id = id;
        Key = key;
        Subscription = subscription;
        Information = information;
    }

    private Customer(Subscription subscription, CustomerInformation information)
    {
        Id ??= CustomerId.Create();
        Key ??= ApiKey.Create();
        Subscription = subscription;
        Information = information;
    }

    public static Customer Create(string name)
        => name switch
        {
            { Length: > 0 } => new(new TrialSubscription(), new CustomerInformation(name)), // does not handle whitespace
            _ => throw new ArgumentException(nameof(name)),
        };
}
