using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Core.Contexts;

namespace Template.Persistence.Context;

public static class DatabaseDbContextFactory 
{
    public static DatabaseDbContext CreateDatabaseDbContext(IServiceProvider serviceProvider)
    {
        var sqlConnectionContext = serviceProvider.GetRequiredService<SqlConnectionContext>();
        
        var databaseDbContextOptions = new DbContextOptionsBuilder<DatabaseDbContext>()
            .UseSqlServer(sqlConnectionContext.SqlConnection, cfg =>
            {
                cfg.MigrationsAssembly(typeof(DatabaseDbContext).Assembly.FullName);
                cfg.MigrationsHistoryTable($"__EF{nameof(DatabaseDbContext)}MigrationsHistory");
            });
        
        return new DatabaseDbContext(databaseDbContextOptions.Options);
    }
}