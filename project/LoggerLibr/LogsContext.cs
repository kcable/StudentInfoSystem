using System;
using System.Data.Entity;

namespace LoggerLibr
{
    public class LogsContext : DbContext

    {
        public DbSet<Log> Logs { get; set; }
        public LogsContext(string serverName, string dbName) : base("Server=" + serverName + "\\SQLEXPRESS;" + // adding the posibility to use different servers and databases
            "Initial Catalog=" + dbName + ";" +                                                                // the code creates a Log table in the database via the log Context        
            "Integrated Security=true;" +
            "Trusted_Connection=true;" +
            "MultipleActiveResultSets=true")
        {
        }
    }
}
