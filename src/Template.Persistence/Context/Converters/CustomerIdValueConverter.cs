using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Domain.Entities;

namespace Template.Persistence.Context.Converters;

internal sealed class CustomerIdValueConverter : ValueConverter<CustomerId, Guid>
{
    public CustomerIdValueConverter() 
        : base(
            obj => obj.Id, 
            val => CustomerId.Create(val))
    {
    }
}
