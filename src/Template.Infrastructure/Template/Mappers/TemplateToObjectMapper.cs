using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Models.Template;

namespace Template.Infrastructure.Template.Mappers
{

    internal sealed class TemplateToObjectMapper : ITemplateMapper<TemplateAggregateRoot, object>
    {
        public Task<object?> Map(TemplateAggregateRoot from)
        {
            return Task.FromResult(from as object);
        }

        public Task<TemplateAggregateRoot?> Map(object to)
        {
            return Task.FromResult(to as TemplateAggregateRoot ?? default);
        }
    }
}
