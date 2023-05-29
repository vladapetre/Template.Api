using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Template.Outbox.Contexts.Outbox;
internal class OutboxContext : DbContext
{
    private const string SCHEMA = "outbox";
    public OutboxContext(DbContextOptions<OutboxContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SCHEMA);

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();

        base.OnModelCreating(modelBuilder);
    }
}

