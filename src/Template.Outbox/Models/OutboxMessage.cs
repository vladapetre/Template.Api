using System.Text.Json;

namespace Template.Outbox.Models;

internal class OutboxMessage
{
    public Guid Id { get; init; }
    public virtual string Type { get; init; }
    public virtual string Payload { get; init; }

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }

    public virtual OutboxMessageStatus Status { get; init; }

    public OutboxMessage(object message)
    {
        Type = message.GetType().FullName + ", " + message.GetType().Assembly.GetName().Name;
        Payload = JsonSerializer.Serialize(message);
        Status = OutboxMessageStatus.Queued;
    }

    public virtual object? Message => JsonSerializer.Deserialize(Payload, System.Type.GetType(Type) ?? typeof(string));
}

