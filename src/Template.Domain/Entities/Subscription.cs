namespace Template.Domain.Entities;

public abstract record class Subscription
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