namespace Template.Persistence.Configuration;

internal sealed class PersistenceConfiguration
{
    public required ConnectionStrings ConnectionStrings { get; init; }
}

internal sealed record ConnectionStrings
{
    public required string DatabaseDbContext { get; init; }
    public required string RabbitMQ { get; init; }
}