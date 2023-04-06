using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Models.Template.Repositories;
using Template.Persistence.Contexts;
using Template.Persistence.Repositories;

namespace Template.Persistence;

public static class AssemblyRegistration
{
    public static IServiceCollection RegisterPersistenceServices(this ServiceCollection services)
    {

        services.AddDbContext<TemplateContext>((options) =>
        {
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
        });


        services.AddTransient<ITemplateRepository, TemplateRepository>();
        return services;
    }
}
