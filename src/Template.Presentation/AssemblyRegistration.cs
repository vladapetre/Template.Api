using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Template.Presentation.Components.Customers.CreateCustomer;

namespace Template.Presentation;

public static class AssemblyRegistration
{
    public static IServiceCollection AddPresentation( this IServiceCollection services )
    {
        return services;
    }

    public static IEndpointRouteBuilder MapEndpoints( this IEndpointRouteBuilder endpointRouteBuilder )
    {
        endpointRouteBuilder.MapCreateCustomerEndpoint();

        return endpointRouteBuilder;
    }
}
