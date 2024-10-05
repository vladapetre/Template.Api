using Microsoft.Extensions.DependencyInjection;
using Template.Application.Components.Customers.Requests.CreateCustomer;

namespace Template.Application;

public static class AssemblyRegistration
{
    public static IServiceCollection AddApplication( this IServiceCollection services )
    {
        services.AddScoped<ICreateCustomerCommandHandler, CreateCustomerCommandHandler>();

        return services;
    }

}
