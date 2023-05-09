using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Outbox.Models;

namespace Template.Persistence.Example.Configurations.Converters;

internal sealed class OutboxMessageStatusConverter : ValueConverter<OutboxMessageStatus, string>
{
    public OutboxMessageStatusConverter()
        : base((message) => message.Name, (name) => name)
    {

    }
}
