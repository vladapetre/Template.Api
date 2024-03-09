using Template.Domain.Components.Weather;

namespace Template.Application.Components.Weather.Queries;
public sealed class GetWeatherQueryResult
{
    public List<WeatherAggregate> Weather { get; init; } = new List<WeatherAggregate>();
}

