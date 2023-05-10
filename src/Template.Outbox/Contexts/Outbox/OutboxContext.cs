using Microsoft.EntityFrameworkCore;
using Template.Outbox.Models;
using Template.Outbox.Models.Configurations;

namespace Template.Outbox.Contexts.Outbox;
internal class OutboxContext : DbContext
{
    private const string SCHEMA = "outbox";
    public OutboxContext(DbContextOptions<OutboxContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SCHEMA);
        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<OutboxMessage> OutboxMessage { get; set; }
}

