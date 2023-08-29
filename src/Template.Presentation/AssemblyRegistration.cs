
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Template.Host.Middleware;

namespace Template.Presentation;

public static class AssemblyRegistration
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        var assembly = typeof(AssemblyRegistration).Assembly;

        services
            .AddControllers()
            .AddApplicationPart(assembly);

        return services;
    }

    public static IApplicationBuilder UsePresentationServices(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<CorrelationMiddleware>();

        return builder;
    }
}
