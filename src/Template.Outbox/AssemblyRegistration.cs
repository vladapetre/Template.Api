using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Outbox.Configuration;
using Template.Persistence.Context;

namespace Template.Outbox;

public static class AssemblyRegistration
{
    public static IServiceCollection AddOutbox( this IServiceCollection services, IConfiguration configuration )
    {
        var outboxConfiguration = configuration
            .GetSection(nameof(OutboxConfiguration))
            .Get<OutboxConfiguration>()
                ?? throw new ArgumentNullException(nameof(OutboxConfiguration));

        services.AddMassTransit(config =>
        {
            config.AddEntityFrameworkOutbox<OutboxContext>(cfg =>
            {
                cfg.QueryDelay = TimeSpan.FromSeconds(30);
                cfg.UseSqlite().UseBusOutbox();
            });

            config.SetKebabCaseEndpointNameFormatter();

            config.UsingRabbitMq(( ctx, cfg ) =>
            {
                cfg.Host(outboxConfiguration.RabbitMQConnectionString);
                cfg.UseMessageRetry(retry => retry.Exponential(10, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(5)));
                cfg.ConfigureEndpoints(ctx);
            });
        });
        return services;
    }

}
