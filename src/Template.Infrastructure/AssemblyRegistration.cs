using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Models.Example;
using Template.Infrastructure.Example.Mappers;
using Template.Infrastructure.Mappers;

namespace Template.Infrastructure;

public static class AssemblyRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        services.AddTransient<IMapper<ExampleAggregateRoot, object>, ExampleToObjectMapper>();

        return services;
    }
}
