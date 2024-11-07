using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Components.Customers.Models;

namespace Template.Persistence.Context;

public class DatabaseDbContext : DbContext
{
    public DbSet<Customer> Customer { get; init; }

    public DatabaseDbContext( DbContextOptions<DatabaseDbContext> options )
        : base(options)
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}