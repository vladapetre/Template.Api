using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Behaviors;

namespace Template.Application;

public static class AssemblyRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = typeof(AssemblyRegistration).Assembly;

        services.AddMediatR((configuration) =>
        {
            configuration.RegisterServicesFromAssembly(assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
