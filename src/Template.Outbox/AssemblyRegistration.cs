using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Outbox.Configuration;
using Template.Outbox.Context;
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
        
        services.AddDbContext<OutboxDbContext>(options =>
        {
            options.UseSqlite(outboxConfiguration.ConnectionStrings.OutboxDbContext,
                cfg =>
                {
                    cfg.MigrationsAssembly(typeof(OutboxDbContext).Assembly.FullName);
                    cfg.MigrationsHistoryTable($"__EF{nameof(OutboxDbContext)}MigrationsHistory");
                });
            
        });
        
        services.AddMassTransit(config =>
        {
            config.AddEntityFrameworkOutbox<OutboxDbContext>(cfg =>
            {
                cfg.QueryDelay = TimeSpan.FromSeconds(30);
                cfg.DuplicateDetectionWindow = TimeSpan.FromMinutes(1);
                cfg.UseSqlite().UseBusOutbox();
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
    }
}