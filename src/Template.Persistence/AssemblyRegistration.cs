using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Components.Weather.Repositories;
using Template.Persistence.Components.Weather;
using Template.Persistence.Context;

namespace Template.Persistence;
public static class AssemblyRegistration
{
    public static IServiceCollection AddPersistenceAssembly(this IServiceCollection services)
    {
        services.AddDbContext<TemplateDbContext>((svcCollection, options) =>
        {
            options.UseSqlServer("name=ConnectionStrings:TemplateContext");
        });

        services.AddScoped<IWeatherRepository, WeatherRepository>();

        return services;
    }
}
