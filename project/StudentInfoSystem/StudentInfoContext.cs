using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
              Database.SetInitializer<StudentInfoContext>(null);
              base.OnModelCreating(modelBuilder);
          }*/


        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect)
        {

        }
    }
}
