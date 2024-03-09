using Template.Domain.Abstractions;

namespace Template.Domain.Components.Weather.Repositories;
public interface IWeatherRepository : IRepository<WeatherAggregate>
{
    Task<List<WeatherAggregate>> GetWeatherForecastStartingWithDay(DateTime day);
}
