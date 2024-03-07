using System.ComponentModel.DataAnnotations;

namespace Template.Module.Presentation.Controllers.Weather;

public sealed record GetWeatherRequest([FromQuery][Required]DateTime? Date) 
{
}
