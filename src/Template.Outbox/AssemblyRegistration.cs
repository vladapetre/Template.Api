using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Outbox.Components.Abstract;
using Template.Outbox.Configuration;
using Template.Outbox.Context;
using Template.Persistence.Components.Abstract;
using Template.Persistence.Context;
using Template.Transaction.Configuration.RabbitMQ;

namespace Template.Outbox;

public static class AssemblyRegistration
{
    public static void AddOutbox(this IServiceCollection services, IConfiguration configuration, Action<IBusRegistrationConfigurator>? configureConsumers = null)
    {
        
        var outboxConfiguration = configuration
                                      .GetSection(nameof(OutboxConfiguration))
                                      .Get<OutboxConfiguration>()
                                  ?? throw new ArgumentNullException(nameof(OutboxConfiguration));
        
        services.AddScoped<IDbContextFactory<OutboxDbContext>, OutboxDbContextFactory>();
        services.AddScoped<OutboxDbContext>(provider => provider.GetRequiredService<IDbContextFactory<OutboxDbContext>>().CreateDbContext());
        
        services.AddMassTransit(config =>
        {
            config.AddEntityFrameworkOutbox<OutboxDbContext>(cfg =>
            {
                cfg.QueryDelay = TimeSpan.FromSeconds(30);
                cfg.DuplicateDetectionWindow = TimeSpan.FromMinutes(1);
                cfg.UseSqlServer().UseBusOutbox();
            });
            
            config.SetKebabCaseEndpointNameFormatter();

            config.UsingRabbitMq(( ctx, cfg ) =>
            {
                cfg.Host(outboxConfiguration.ConnectionStrings.RabbitMQ);
                cfg.MessageTopology.SetEntityNameFormatter(new EntityNameFormatter());

                cfg.UsePublishFilter(typeof(CorrelationContextPublishFilter<>), ctx);
                cfg.UseSendFilter(typeof(CorrelationContextSendFilter<>), ctx);
                cfg.UseConsumeFilter(typeof(CorrelationContextConsumeFilter<>), ctx);
                cfg.UseConsumeFilter(typeof(LoggingScopeConsumeFilter<>), ctx);
                
                cfg.UseMessageRetry(retry =>
                    retry.Exponential(10, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(5)));
                cfg.ConfigureEndpoints(ctx);
            });

            configureConsumers?.Invoke(config);
        });

        services.AddScoped<IEventHandler, OutboxEventHandler>();
    }
}