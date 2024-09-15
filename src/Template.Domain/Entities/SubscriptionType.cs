using Template.Core.Types;

namespace Template.Domain.Entities;

public sealed record class SubscriptionType : Enumeration
{
    public SubscriptionType(int id, string name) : base(id, name)
    {
    }

    public static SubscriptionType Trial = new(1, "Test");
}