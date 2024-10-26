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
    public static void AddTransaction(this IServiceCollection services, IConfiguration configuration, Action<IBusRegistrationConfigurator>? configureConsumers = null)
    {
        var transactionConfiguration = configuration
                                           .GetSection(nameof(TransactionConfiguration))
                                           .Get<TransactionConfiguration>()
                                       ?? throw new ArgumentNullException(nameof(TransactionConfiguration));

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlite(transactionConfiguration.ConnectionStrings.DatabaseContext,
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
                cfg.DuplicateDetectionWindow = TimeSpan.FromMinutes(1);
                cfg.UseSqlite().UseBusOutbox();
            });

            
            
            config.SetKebabCaseEndpointNameFormatter();

            config.UsingRabbitMq(( ctx, cfg ) =>
            {
                cfg.MessageTopology.SetEntityNameFormatter(new TransactionEntityNameFormatter());
                cfg.Host(transactionConfiguration.ConnectionStrings.RabbitMQ);
                cfg.UseMessageRetry(retry =>
                    retry.Exponential(10, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(5)));
                cfg.ConfigureEndpoints(ctx);
            });

            configureConsumers?.Invoke(config);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}