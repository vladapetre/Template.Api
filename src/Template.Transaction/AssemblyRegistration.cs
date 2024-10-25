using MassTransit;
using MassTransit.Middleware.InMemoryOutbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Components.Abstract.Persistence;
using Template.Application.Components.Customers.Persistence;
using Template.Transaction.Components.Abstract;
using Template.Transaction.Components.Customers;
using Template.Transaction.Configuration;
using Template.Transaction.Context;

namespace Template.Transaction;

public static class AssemblyRegistration
{
    public static IServiceCollection AddPersistence( this IServiceCollection services, IConfiguration configuration )
    {
        var persistenceConfiguration = configuration
           .GetSection(nameof(PersistenceConfiguration))
           .Get<PersistenceConfiguration>()
                ?? throw new ArgumentNullException(nameof(PersistenceConfiguration));

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlite(persistenceConfiguration.ConnectionStrings.DatabaseContext,
                cfg =>
                {
                    cfg.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName);
                    cfg.MigrationsHistoryTable($"__EF{nameof(DatabaseContext)}MigrationsHistory");
                });
        });

        services.AddMassTransit(config =>
        {
            config.AddEntityFrameworkOutbox<DatabaseContext>(cfg =>
            {
                cfg.QueryDelay = TimeSpan.FromSeconds(30);
                cfg.UseSqlite().UseBusOutbox();
            });

            config.SetKebabCaseEndpointNameFormatter();

            config.UsingInMemory(( ctx, cfg ) =>
            {
                //cfg.Host(outboxConfiguration.ConnectionStrings.RabbitMQ);
                cfg.UseMessageRetry(retry =>
                    retry.Exponential(10, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(5)));
                cfg.ConfigureEndpoints(ctx);
            });
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}