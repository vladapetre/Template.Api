using Microsoft.Extensions.DependencyInjection;
using Template.Module.Presentation.Filters;

namespace Template.Module.Presentation;
public static class AssemblyRegistration
{
    public static IServiceCollection AddPresentationAssembly(this IServiceCollection services)
    {
        var assembly = typeof(AssemblyRegistration).Assembly;

        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        services.AddScoped<ValidationFilterAttribute>();

        services
            .AddControllers()
            .AddApplicationPart(assembly);

        return services;
    }
}
