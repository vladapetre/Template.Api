
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Components.Weather.Repositories;

namespace Template.Domain;
public static class AssemblyRegistration
{
    public static IServiceCollection AddDomainAssembly(this IServiceCollection services)
    {

        services.AddScoped<IWeatherRepository, WeatherRepository>();

        return services;
    }
}
