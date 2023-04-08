
using Microsoft.Extensions.DependencyInjection;

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
}
