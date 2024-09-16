using Template.Core.Primitives;

namespace Template.Domain.Components.Customers;

public sealed record class SubscriptionType : Enumeration
{
    public SubscriptionType( int id, string name ) : base(id, name)
    {
    }

    public static readonly SubscriptionType Trial = new(1, "Test");
}