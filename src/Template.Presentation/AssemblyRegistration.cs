using Microsoft.Extensions.DependencyInjection;

namespace Template.Presentation;
public static class AssemblyRegistration
{
    public static IServiceCollection AddPresentationAssembly(this IServiceCollection services)
    {
        var assembly = typeof(AssemblyRegistration).Assembly;

        services
            .AddControllers()
            .AddApplicationPart(assembly);

        return services;
    }
}
