using Template.Domain.Components.Weather.Repositories;

namespace Template.Application.Components.Weather.Queries;
public sealed class GetWeatherQueryHandler : IRequestHandler<GetWeatherQuery, Result<GetWeatherQueryResult, Exception>>
{
    private readonly IWeatherRepository _weatherRepository;

    public GetWeatherQueryHandler(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }
    public async Task<Result<GetWeatherQueryResult, Exception>> HandleAsync(GetWeatherQuery request)
    {
        try
        {
            var weatherForecastDay = request.Date ?? DateTime.Today;

            var weatherForecast = await _weatherRepository.GetWeatherForecastStartingWithDay(weatherForecastDay);

            return new GetWeatherQueryResult { Weather = weatherForecast };
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
