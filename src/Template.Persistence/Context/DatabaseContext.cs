using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Components.Customers.Models;

namespace Template.Transaction.Context;

public sealed class DatabaseContext : DbContext
{
    public DbSet<Customer> Customer { get; init; }

    public DatabaseContext( DbContextOptions<DatabaseContext> options )
        : base(options)
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}