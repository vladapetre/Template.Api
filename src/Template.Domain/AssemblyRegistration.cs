using Microsoft.Extensions.DependencyInjection;

namespace Template.Domain;

public static class AssemblyRegistration
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services;
    }
}
