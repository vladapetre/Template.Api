using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Core.Contexts;

namespace Template.Outbox.Context;

public static class OutboxDbContextFactory 
{
    public static OutboxDbContext CreateOutboxDbContext(IServiceProvider serviceProvider)
    {
        var sqlConnectionContext = serviceProvider.GetRequiredService<SqlConnectionContext>();
        
        var outboxDbContextOptions = new DbContextOptionsBuilder<OutboxDbContext>()
            .UseSqlServer(sqlConnectionContext.SqlConnection, cfg =>
            {
                cfg.MigrationsAssembly(typeof(OutboxDbContext).Assembly.FullName);
                cfg.MigrationsHistoryTable($"__EF{nameof(OutboxDbContext)}MigrationsHistory", schema:"outbox");
            });
        
        return new OutboxDbContext(outboxDbContextOptions.Options);
    }
}