using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Models.Template.Repositories;
using Template.Persistence.Contexts;
using Template.Persistence.Template.Repositories;

namespace Template.Persistence;

public static class AssemblyRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {

        services.AddDbContext<TemplateContext>((options) =>
        {
            options.UseSqlServer("name=ConnectionStrings:TemplateContext");
        });


        services.AddTransient<ITemplateRepository, TemplateRepository>();
        return services;
    }
}
