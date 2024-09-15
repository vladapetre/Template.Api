namespace Template.Domain.Entities;

public abstract record class Subscription
{
    public abstract SubscriptionType Type { get; }
}

public sealed record class TrialSubscription : Subscription
{
    public override SubscriptionType Type => SubscriptionType.Trial;
}