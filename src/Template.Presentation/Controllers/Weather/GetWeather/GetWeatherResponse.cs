namespace Template.Presentation.Controllers.Weather.GetWeather;

public sealed record GetWeatherResponse(DateOnly Date, decimal TemperatureC, decimal TemperatureF, string? Summary)
{
}
