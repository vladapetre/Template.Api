using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Components.Abstract.Persistence;
using Template.Application.Components.Customers.Persistence;
using Template.Core.Contexts;
using Template.Persistence.Components.Abstract;
using Template.Persistence.Components.Customers;
using Template.Persistence.Context;

namespace Template.Persistence;

public static class AssemblyRegistration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbContextFactory<DatabaseDbContext>, DatabaseDbContextFactory>();
        services.AddScoped<DatabaseDbContext>(provider => provider.GetRequiredService<IDbContextFactory<DatabaseDbContext>>().CreateDbContext());
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}