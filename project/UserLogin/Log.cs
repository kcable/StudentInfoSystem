using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Log
    {
        public Log(string activity, DateTime date, string username)
        {
            this.activity = activity;
            this.date = date;
            this.username = username;
        }
        public int LogId { get; set; }
        public DateTime date { get; set; }
        public string username { get; set; }
        public string activity { get; set; }

    }
}
