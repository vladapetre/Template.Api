using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Domain.Components.Customers;

namespace Template.Persistence.Context.Components.Customers.Converters;

internal sealed class CustomerIdValueConverter : ValueConverter<CustomerId, Guid>
{
    public CustomerIdValueConverter()
        : base(
            obj => obj.Id,
            val => CustomerId.Create(val))
    {
    }
}
