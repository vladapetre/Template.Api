namespace Template.Domain.Components.Weather.Repositories;
internal class WeatherRepository : IWeatherRepository
{
    public IUnitOfWork UnitOfWork => throw new NotImplementedException();

    public async Task<List<WeatherAggregate>> GetWeatherForecastStartingWithDay(DateTime day)
    {

        var weatherForecast = Enumerable.Range(1, 5).Select(index =>
              new WeatherAggregate
              (
                  DateOnly.FromDateTime(day.AddDays(index)),
                  Temperature.FromCelsius(Random.Shared.Next(-20, 55))
              ))
          .ToList();

        return weatherForecast;
    }
}
