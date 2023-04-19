using Microsoft.EntityFrameworkCore;
using Template.Domain.Models.Template;
using Template.Domain.Primitives;
using Template.Persistence.Template.Configurations;

namespace Template.Persistence.Contexts;

internal sealed class TemplateContext : DbContext, IUnitOfWork
{
    public TemplateContext(DbContextOptions<TemplateContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new TemplateAggregateRootConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);

        return true;
    }

    public DbSet<TemplateAggregateRoot> Template { get; set; }
}
