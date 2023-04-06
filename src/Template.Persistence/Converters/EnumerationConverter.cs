using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Domain.Models.Template;
using Template.Domain.Primitives;

namespace Template.Persistence.Converters;

internal abstract class EnumerationConverter<T> : ValueConverter<T, int> where T : IEnumeration
{
    protected EnumerationConverter(ConverterMappingHints? mappingHints = null) 
        : base(enumeration => enumeration.Id, enumerationId => IEnumeration.FromValue<T>(enumerationId), mappingHints)
    {
    }
}
