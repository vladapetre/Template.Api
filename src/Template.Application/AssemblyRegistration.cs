using Microsoft.Extensions.DependencyInjection;
using Template.Application.Components.Weather.GetWeather;

namespace Template.Application;
public static class AssemblyRegistration
{
    public static IServiceCollection AddApplicationAssembly(this IServiceCollection services)
    {
        var assembly = typeof(AssemblyRegistration).Assembly;

        services.AddRequestHandlers();

        return services;
    }

    private static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<GetWeatherQuery, Result<GetWeatherQueryResult, Exception>>, GetWeatherQueryHandler>();
        return services;
    }
}
