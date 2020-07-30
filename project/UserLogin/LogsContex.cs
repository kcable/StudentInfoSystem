using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LogsContex : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public LogsContex() : base(Properties.Settings.Default.DbConnect)
        {

        }
    }
}
