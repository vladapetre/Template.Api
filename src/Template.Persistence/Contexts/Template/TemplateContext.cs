using Microsoft.EntityFrameworkCore;
using Template.Domain.Models.Example;
using Template.Domain.Primitives;
using Template.Persistence.Example.Configurations;

namespace Template.Persistence.Contexts.Template;

internal sealed class TemplateContext : DbContext, IUnitOfWork
{
    private const string SCHEMA = "template";

    public TemplateContext(DbContextOptions<TemplateContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SCHEMA);
        modelBuilder.ApplyConfiguration(new ExampleAggregateRootConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ExampleAggregateRoot> Example { get; set; }
}
