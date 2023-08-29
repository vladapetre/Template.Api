using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Mediator.Behaviors;
using Template.Application.Mediator.Messaging.Events;
using Template.Domain.Primitives;

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
            configuration.AddOpenBehavior(typeof(ExceptionHandlingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });

        services.AddTransient<IEventBus, EventBus>();

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
