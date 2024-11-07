using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Components.Abstract.Persistence;
using Template.Application.Components.Customers.Persistence;
using Template.Persistence.Components.Abstract;
using Template.Persistence.Components.Customers;
using Template.Persistence.Context;
using Template.Persistence.Configuration;

namespace Template.Persistence;

public static class AssemblyRegistration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var persistenceConfiguration = configuration
                                           .GetSection(nameof(PersistenceConfiguration))
                                           .Get<PersistenceConfiguration>()
                                       ?? throw new ArgumentNullException(nameof(PersistenceConfiguration));

        services.AddDbContext<DatabaseDbContext>(options =>
        {
            options.UseSqlite(persistenceConfiguration.ConnectionStrings.DatabaseDbContext,
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