using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Core.Types;

namespace Template.Persistence.Context.Converters;

internal class EnumerationValueConverter<TEnumeration> : ValueConverter<Enumeration, int> where TEnumeration : Enumeration
{
    public EnumerationValueConverter()
        : base(
             obj => obj.Id,
             val => Enumeration.FromValue<TEnumeration>(val))
    {
    }
}
