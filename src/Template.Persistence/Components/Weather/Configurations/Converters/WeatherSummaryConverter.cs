using Template.Domain.Components.Weather;

namespace Template.Persistence.Components.Weather.Configurations.Converters;
internal sealed class WeatherSummaryConverter : ValueConverter<WeatherSummary, int>
{
    public WeatherSummaryConverter(ConverterMappingHints? mappingHints = null)
        : base(enumeration => (int)enumeration, enumerationId => (WeatherSummary)enumerationId, mappingHints)
    {
    }
}
