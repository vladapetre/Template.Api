using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;

namespace Template.Persistence.Context;

public sealed class DatabaseContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }

    protected override void OnConfiguring( DbContextOptionsBuilder options )
        => options.UseSqlite($"Data Source=template.db");

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
