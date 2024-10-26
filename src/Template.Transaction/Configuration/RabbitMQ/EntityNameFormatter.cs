using MassTransit;

namespace Template.Transaction.Configuration.RabbitMQ;

internal sealed class EntityNameFormatter : IEntityNameFormatter
{
    public string FormatEntityName<T>() => $"Events.{typeof(T).Name}";
}