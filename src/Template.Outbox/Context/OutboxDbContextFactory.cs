using Microsoft.EntityFrameworkCore;
using Template.Core.Contexts;

namespace Template.Outbox.Context;

public class OutboxDbContextFactory : IDbContextFactory<OutboxDbContext>
{
    private readonly SqlConnectionContext sqlConnectionContext;

    public OutboxDbContextFactory(SqlConnectionContext sqlConnectionContext)
    {
        this.sqlConnectionContext = sqlConnectionContext;
    }
    
    public OutboxDbContext CreateDbContext()
    {
        var outboxDbContextOptions = new DbContextOptionsBuilder<OutboxDbContext>()
            .UseSqlite(sqlConnectionContext.SqliteConnection, cfg =>
            {
                cfg.MigrationsAssembly(typeof(OutboxDbContext).Assembly.FullName);
                cfg.MigrationsHistoryTable($"__EF{nameof(OutboxDbContext)}MigrationsHistory");
            });
        
        return new OutboxDbContext(outboxDbContextOptions.Options);
    }
}