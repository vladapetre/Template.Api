namespace Template.Application.Components.Weather.Queries;
public sealed class GetWeatherQueryHandler : IRequestHandler<GetWeatherQuery, Result<GetWeatherQueryResult, Exception>>
{
    public async Task<Result<GetWeatherQueryResult, Exception>> HandleAsync(GetWeatherQuery request)
    {
        try
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var weatherForecast = Enumerable.Range(1, 5).Select(index =>
               new Weather
               (
                   DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                   Random.Shared.Next(-20, 55),
                   summaries[Random.Shared.Next(summaries.Length)]
               ))
           .ToList();

            return new GetWeatherQueryResult { Weather = weatherForecast };
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
