using Microsoft.EntityFrameworkCore;
using Template.Core.Contexts;

namespace Template.Persistence.Context;

public class DatabaseDbContextFactory : IDbContextFactory<DatabaseDbContext>
{
    private readonly SqlConnectionContext sqlConnectionContext;

    public DatabaseDbContextFactory(SqlConnectionContext sqlConnectionContext)
    {
        this.sqlConnectionContext = sqlConnectionContext;
    }
    
    public DatabaseDbContext CreateDbContext()
    {
        var databaseDbContextOptions = new DbContextOptionsBuilder<DatabaseDbContext>()
            .UseSqlServer(sqlConnectionContext.SqlConnection, cfg =>
            {
                cfg.MigrationsAssembly(typeof(DatabaseDbContext).Assembly.FullName);
                cfg.MigrationsHistoryTable($"__EF{nameof(DatabaseDbContext)}MigrationsHistory");
            });
        
        return new DatabaseDbContext(databaseDbContextOptions.Options);
    }
}