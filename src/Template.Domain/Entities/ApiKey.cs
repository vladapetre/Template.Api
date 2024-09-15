namespace Template.Domain.Entities;

public sealed record class ApiKey
{
    public Guid Key { get; private init; }
    public bool Expired { get; private init; }

    private ApiKey(Guid key) => (Key, Expired) = (key, false);

    public static ApiKey Create() => new(Guid.CreateVersion7());
}
