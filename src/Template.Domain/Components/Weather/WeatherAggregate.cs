using Template.Domain.Abstractions;

namespace Template.Domain.Components.Weather;
public sealed class WeatherAggregate : IAggregateRoot
{
    public Temperature Temperature { get; set; }
    public DateOnly Day { get; set; }
    public WeatherAggregate(DateOnly day, Temperature temperature)
    {
        Temperature = temperature;
        Day = day;
    }

    public WeatherSummary Summary => Temperature switch
    {
        { Celsius: <= 0 } => WeatherSummary.Freezing,
        { Celsius: > 0 and <= 5 } => WeatherSummary.Cool,
        { Celsius: > 5 and <= 10 } => WeatherSummary.Bracing,
        { Celsius: > 10 and <= 15 } => WeatherSummary.Chilly,
        { Celsius: > 15 and <= 20 } => WeatherSummary.Balmy,
        { Celsius: > 20 and <= 25 } => WeatherSummary.Warm,
        { Celsius: > 25 and <= 30 } => WeatherSummary.Hot,
        _ => WeatherSummary.Scorching
    };
}
