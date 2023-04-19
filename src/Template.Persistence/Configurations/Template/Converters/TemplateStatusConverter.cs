using Template.Domain.Models.Template;
using Template.Persistence.Converters;

namespace Template.Persistence.Configurations.Template.Converters;

internal sealed class TemplateStatusConverter : EnumerationConverter<TemplateStatus>
{
    public TemplateStatusConverter() : base() { }
}
