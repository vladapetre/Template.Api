using Microsoft.Extensions.DependencyInjection;

namespace Template.Presentation;

public static class AssemblyRegistration
{
    public static IServiceCollection RegisterPresentationServices(this ServiceCollection services)
    {
        return services;
    }
}
