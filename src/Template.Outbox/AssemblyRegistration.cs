using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.Application.Mediator.Messaging;
using Template.Outbox;
using Template.Outbox.Contexts.Outbox;
using Template.Outbox.Messaging;
using Template.Outbox.Settings;
using Template.Persistence.Contexts.Interceptors;

namespace Template.Persistence;

public static class AssemblyRegistration
{
    public static IServiceCollection AddOutboxServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<INotificationBus, NotificationBus>();

        services.AddDbContext<OutboxContext>((svcCollection, options) =>
        {
            options.UseSqlServer("name=ConnectionStrings:OutboxContext");
        });

        var outboxSettings =
            configuration.GetSection(nameof(OutboxSettings)).Get<OutboxSettings>()
            ?? throw new ArgumentNullException(nameof(OutboxSettings));

        services.AddMassTransit(mass =>
        {
            mass.AddEntityFrameworkOutbox<OutboxContext>(cfg =>
            {
                cfg.UseSqlServer();
                cfg.UseBusOutbox();
                cfg.QueryDelay = TimeSpan.FromSeconds(1);
            });

            mass.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
                cfg.AutoStart = true;
                cfg.Host(outboxSettings.Uri, "/", configure =>
                {
                    configure.Username(outboxSettings.UserName);
                    configure.Password(outboxSettings.Password);
                });
            });

        });

        return services;
    }

    public static IHost UseOutboxServices(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var database = scope.ServiceProvider.GetRequiredService<OutboxContext>();
            database.Database.Migrate();
        }

        return host;
    }
}
