using Template.Core.Primitives;

namespace Template.Domain.Components.Customers.Models;

public abstract record class Subscription : ValueObject
{
    public abstract SubscriptionType Type { get; protected init; }
}

public sealed record class TrialSubscription : Subscription
{
    public override SubscriptionType Type { get; protected init; }

    public TrialSubscription()
    {
        Type = SubscriptionType.Trial;
    }
}