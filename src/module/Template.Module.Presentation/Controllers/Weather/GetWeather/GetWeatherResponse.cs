namespace Template.Module.Presentation.Controllers.Weather.GetWeather;

public sealed record GetWeatherResponse(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
