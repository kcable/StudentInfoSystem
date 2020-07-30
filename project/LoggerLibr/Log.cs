using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace LoggerLibr


{
    public class Log

    {
        public Log(string activity, DateTime date, string username)  //class which objects stored in db
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
