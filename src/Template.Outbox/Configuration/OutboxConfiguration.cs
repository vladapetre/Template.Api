namespace Template.Outbox.Configuration;

internal sealed class OutboxConfiguration
{
    public required ConnectionStrings ConnectionStrings { get; init; }
}

internal sealed record ConnectionStrings
{
    public required string RabbitMQ { get; init; }
}