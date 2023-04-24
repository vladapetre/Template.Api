using Microsoft.EntityFrameworkCore;
using Template.Domain.Models.Example;
using Template.Domain.Primitives;
using Template.Persistence.Example.Configurations;

namespace Template.Persistence.Contexts.Template;

internal sealed class TemplateContext : DbContext, IUnitOfWork
{
    public TemplateContext(DbContextOptions<TemplateContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new ExampleAggregateRootConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        return true;
    }

    public DbSet<ExampleAggregateRoot> Example { get; set; }
}
