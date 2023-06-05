using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.Domain.Models.Example.Repositories;
using Template.Persistence.Contexts.Interceptors;
using Template.Persistence.Contexts.Template;
using Template.Persistence.Example.Repositories;

namespace Template.Persistence;

public static class AssemblyRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<RaiseEntityEventsSaveChangesInterceptor>();
        services.AddDbContext<TemplateContext>((svcCollection, options) =>
        {
            options.UseSqlServer("name=ConnectionStrings:TemplateContext");
            options.AddInterceptors(svcCollection.GetRequiredService<RaiseEntityEventsSaveChangesInterceptor>());
        });

        services.AddTransient<IExampleRepository, ExampleRepository>();
        return services;
    }

    public static IHost UsePersistenceServices(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var database = scope.ServiceProvider.GetRequiredService<TemplateContext>();
            database.Database.Migrate();
        }

        return host;
    }
}
