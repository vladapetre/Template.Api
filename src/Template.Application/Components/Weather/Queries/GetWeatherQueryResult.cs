namespace Template.Application.Components.Weather.GetWeather;
public sealed class GetWeatherQueryResult
{
    public List<Weather> Weather { get; init; } = new List<Weather>();
}

public sealed record Weather(DateOnly Date, int TemperatureC, string? Summary);
