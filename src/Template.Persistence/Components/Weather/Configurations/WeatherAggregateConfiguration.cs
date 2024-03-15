using Template.Domain.Components.Weather;
using Template.Persistence.Components.Weather.Configurations.Converters;

namespace Template.Persistence.Components.Weather.Configurations;
public sealed class WeatherAggregateConfiguration : IEntityTypeConfiguration<WeatherAggregate>
{
    private const string TEMPLATE_TABLE_NAME = "Weather";

    public void Configure(EntityTypeBuilder<WeatherAggregate> builder)
    {
        builder
            .ToTable(TEMPLATE_TABLE_NAME);

        builder
            .HasKey(template => template.Day);

        builder
            .Property(template => template.Summary)
            .HasConversion<WeatherSummaryConverter>();
    }
}
