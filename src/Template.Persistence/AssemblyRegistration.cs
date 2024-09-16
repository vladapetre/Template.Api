using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Abstract.Persistence;
using Template.Domain.Components.Customers.Persistence;
using Template.Persistence.Abstract;
using Template.Persistence.Components.Customers;
using Template.Persistence.Context;

namespace Template.Persistence;

public static class AssemblyRegistration
{
    public static IServiceCollection AddPersistence( this IServiceCollection services )
    {

        services.AddDbContext<DatabaseContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
