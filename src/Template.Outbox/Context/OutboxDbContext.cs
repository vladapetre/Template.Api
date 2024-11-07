using MassTransit;
using Microsoft.EntityFrameworkCore;
using Template.Persistence.Context;

namespace Template.Outbox.Context;

public sealed class OutboxDbContext : DbContext
{
    public OutboxDbContext(DbContextOptions<OutboxDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema("outbox");
        
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }
}