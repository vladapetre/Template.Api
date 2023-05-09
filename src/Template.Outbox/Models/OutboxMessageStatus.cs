namespace Template.Outbox.Models;
internal class OutboxMessageStatus
{
    public static readonly OutboxMessageStatus Queued = new(1, nameof(Queued).ToLowerInvariant());
    public static readonly OutboxMessageStatus Succeeded = new(2, nameof(Succeeded).ToLowerInvariant());
    public static readonly OutboxMessageStatus Failed = new(2, nameof(Failed).ToLowerInvariant());
    public static readonly OutboxMessageStatus Expired = new(2, nameof(Expired).ToLowerInvariant());

    public OutboxMessageStatus(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; init; }
    public string Name { get; init; }

    public static implicit operator OutboxMessageStatus(string name) => name switch
    {
        nameof(Queued) => Queued,
        nameof(Succeeded) => Succeeded,
        nameof(Failed) => Failed,
        nameof(Expired) => Expired,
        _ => throw new ArgumentOutOfRangeException(nameof(name))
    };
}
