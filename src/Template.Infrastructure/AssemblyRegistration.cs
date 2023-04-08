using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Models.Template;
using Template.Infrastructure.Template.Mappers;

namespace Template.Infrastructure;

public static class AssemblyRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        services.AddTransient<ITemplateMapper<TemplateAggregateRoot, object>, TemplateToObjectMapper>();

        return services;
    }
}
