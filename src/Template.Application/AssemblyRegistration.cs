using Microsoft.Extensions.DependencyInjection;
using Template.Application.Scenarios.CreateCustomer;

namespace Template.Application;

public static class AssemblyRegistration
{
    public static IServiceCollection AddApplication( this IServiceCollection services )
    {
        services.AddScoped<ICreateCustomerCommandHandler, CreateCustomerCommandHandler>();

        return services;
    }

}
