using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Core.Types;

namespace Template.Persistence.Context.Converters;

internal sealed class EnumerationValueConverter<TEnumeration> : ValueConverter<Enumeration, int> where TEnumeration : Enumeration
{
    public EnumerationValueConverter()
        : base(
             obj => obj.Id,
             val => Enumeration.FromValue<TEnumeration>(val))
    {
    }
}
