using Template.Core.Contexts;

namespace Template.Core.Contexts;

public static class ContextFactory
{
    public static CorrelationContext CreateCorrelationContext() => CorrelationContext.Create();
    public static SqlConnectionContext CreateSqlConnectionContext(string connectionString) => SqlConnectionContext.Create(connectionString);

}