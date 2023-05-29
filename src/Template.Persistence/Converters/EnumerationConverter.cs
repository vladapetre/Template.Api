using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Domain.Primitives;

namespace Template.Persistence.Converters;

internal abstract class EnumerationConverter<T> : ValueConverter<T, int> where T : IEnumeration
{
    protected EnumerationConverter(ConverterMappingHints? mappingHints = null)
        : base(enumeration => enumeration.Id, enumerationId => IEnumeration.FromValue<T>(enumerationId), mappingHints)
    {
    }
}
