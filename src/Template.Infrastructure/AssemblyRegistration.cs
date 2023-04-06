using Microsoft.Extensions.DependencyInjection;

namespace Template.Infrastructure;

public static class AssemblyRegistration
{
    public static IServiceCollection RegisterInfrastructureServices(this ServiceCollection services)
    {
        return services;
    }
}
