using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Outbox.Models;

namespace Template.Persistence.Example.Configurations.Converters;

internal sealed class OutboxMessagePayloadConverter : ValueConverter<OutboxMessageStatus, string>
{
    public OutboxMessagePayloadConverter()
        : base((message) => message.Name, (name) => name)
    {

    }
}
