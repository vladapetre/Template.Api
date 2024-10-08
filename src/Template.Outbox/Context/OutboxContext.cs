using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Template.Persistence.Context;

public sealed class OutboxContext : DbContext
{
    protected override void OnConfiguring( DbContextOptionsBuilder options )
        => options.UseSqlite($"Data Source=template.db");

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.HasDefaultSchema("outbox");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
