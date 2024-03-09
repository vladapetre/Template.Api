using System.ComponentModel.DataAnnotations;

namespace Template.Presentation.Controllers.Weather.GetWeather;

public sealed record GetWeatherRequest([FromQuery] DateTime? Date)
{
}
