using Microsoft.Extensions.DependencyInjection;

namespace Template.Presentation;

public static class AssemblyRegistration
{
    public static IServiceCollection AddPresentationServices(this ServiceCollection services)
    {
        return services;
    }
}
