using Template.Domain.Models.Example;
using Template.Persistence.Converters;

namespace Template.Persistence.Example.Configurations.Converters;

internal sealed class ExampleStatusConverter : EnumerationConverter<ExampleStatus>
{
    public ExampleStatusConverter() : base() { }
}
