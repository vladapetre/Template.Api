using MassTransit;

namespace Template.Transaction.Configuration;

internal sealed class TransactionEntityNameFormatter : IEntityNameFormatter
{
    public string FormatEntityName<T>() => $"Events.{typeof(T).Name}";
}