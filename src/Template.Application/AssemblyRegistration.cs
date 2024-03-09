using Microsoft.Extensions.DependencyInjection;
using Template.Application.Components.Weather.Queries;

namespace Template.Application;
public static class AssemblyRegistration
{
    public static IServiceCollection AddApplicationAssembly(this IServiceCollection services)
    {

        services.AddRequestHandlers();

        return services;
    }

    private static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<GetWeatherQuery, Result<GetWeatherQueryResult, Exception>>, GetWeatherQueryHandler>();
        return services;
    }
}
