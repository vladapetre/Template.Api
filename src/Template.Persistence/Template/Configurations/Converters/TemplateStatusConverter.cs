using Template.Domain.Models.Template;
using Template.Persistence.Converters;

namespace Template.Persistence.Template.Configurations.Converters;

internal sealed class TemplateStatusConverter : EnumerationConverter<TemplateStatus>
{
    public TemplateStatusConverter() : base() { }
}
