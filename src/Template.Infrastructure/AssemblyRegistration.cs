using Microsoft.Extensions.DependencyInjection;

namespace Template.Infrastructure;

public static class AssemblyRegistration
{
    public static IServiceCollection AddInfrastructureServices(this ServiceCollection services)
    {
        return services;
    }
}
