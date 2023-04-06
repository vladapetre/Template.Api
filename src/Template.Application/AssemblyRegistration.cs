using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Application;

public static class AssemblyRegistration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        var assembly = typeof(AssemblyRegistration).Assembly;

        services.AddMediatR((configuration) =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
        });

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
