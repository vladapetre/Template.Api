using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Domain.Models.Template;
using Template.Domain.Primitives;
using Template.Persistence.Converters;

namespace Template.Persistence.Configurations.Template.Converters;

internal sealed class TemplateStatusConverter : EnumerationConverter<TemplateStatus>
{
    public TemplateStatusConverter(): base() { }
}
