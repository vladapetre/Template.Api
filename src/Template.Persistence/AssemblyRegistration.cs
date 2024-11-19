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
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var transactionConfiguration = configuration
                                           .GetSection(nameof(TransactionConfiguration))
                                           .Get<TransactionConfiguration>()
                                       ?? throw new ArgumentNullException(nameof(TransactionConfiguration));

        services.AddDbContext<DatabaseDbContext>(options =>
        {
            options.UseSqlite(transactionConfiguration.ConnectionStrings.DatabaseContext,
                cfg =>
                {
                    cfg.MigrationsAssembly(typeof(DatabaseDbContext).Assembly.FullName);
                    cfg.MigrationsHistoryTable($"__EF{nameof(DatabaseDbContext)}MigrationsHistory");
                });
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}