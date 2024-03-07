namespace Template.Module.Presentation.Controllers.Weather.GetWeather;

[ApiController]
public sealed class GetWeatherController : ApiController
{
    public GetWeatherController()
    {

    }

    [HttpGet]
    [Route("weather")]
    public async Task<ActionResult<IList<GetWeatherResponse>>> HandleAsync([FromRoute] GetWeatherRequest request)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecast = Enumerable.Range(1, 5).Select(index =>
           new GetWeatherResponse
           (
               DateOnly.FromDateTime(request?.Date ?? DateTime.Now.AddDays(index)),
               Random.Shared.Next(-20, 55),
               summaries[Random.Shared.Next(summaries.Length)]
           ))
       .ToList();

        return forecast;
    }
}
