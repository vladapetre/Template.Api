using System.Runtime.CompilerServices;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Mediator.Behaviors;
using Template.Application.Mediator.Messaging;
using Template.Domain.Primitives;

namespace Template.Application;

public static class AssemblyRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(AssemblyRegistration).Assembly;

        services.AddMediatR((cfg) =>
        {
            cfg.RegisterServicesFromAssembly(assembly);

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ExceptionHandlingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });

        services.AddTransient<IEventBus, EventBus>();

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
