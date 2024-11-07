using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace Template.Core.Contexts;

public class SqlConnectionContext
{
    public SqlConnection SqlConnection { get; init; }
    public SqliteConnection  SqliteConnection  { get; init; }
    private SqlConnectionContext(string connectionString) 
    {
        SqlConnection = new SqlConnection(connectionString);
        SqliteConnection  = new SqliteConnection (connectionString);
    }

    internal static SqlConnectionContext Create(string connectionString) => new(connectionString);
}