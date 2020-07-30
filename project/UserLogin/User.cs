using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {

        public User(int userRole, string userName, string password, string facultyNumber, DateTime Created, DateTime ValidTo)
        {
            // Console.WriteLine("constructor Called");
            this.Created = Created;
            this.userName = userName;
            this.userRole = userRole;
            this.password = password;
            this.facultyNumber = facultyNumber;
            this.ValidTo = ValidTo;
        }
        public User()
        {

        }
        public DateTime Created { get; set; }
        public DateTime? ValidTo { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string facultyNumber { get; set; }
        public int userRole { get; set; }// if 1 user is ADMIN 
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"Name:{userName} UserId:{UserId} facNum:{facultyNumber} ValidTo:{ValidTo} ";
        }
    }


}




