using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.Outbox;
using Template.Outbox.Contexts.Outbox;
using Template.Persistence.Contexts.Interceptors;

namespace Template.Persistence;

public static class AssemblyRegistration
{
    public static IServiceCollection AddOutboxServices(this IServiceCollection services)
    {

        services.AddSingleton<TimeProvider>();
        services.AddScoped<OutboxMessageTimeStampsInterceptor>();
        services.AddDbContext<OutboxContext>((svcCollection, options) =>
        {
            options.UseSqlServer("name=ConnectionStrings:OutboxContext");
            options.AddInterceptors(svcCollection.GetRequiredService<OutboxMessageTimeStampsInterceptor>());
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
