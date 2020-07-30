using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public string firstName { get; set; }
        public string sureName { get; set; }
        public string lastName { get; set; }
        public string faculty { get; set; }
        public string specialnost { get; set; }
        public string major { get; set; }
        public string status { get; set; }
        public string facultyNumber { get; set; }
        public int course { get; set; }
        public int potok { get; set; }
        public int group { get; set; }
        // public string diploma { get; set; }
        public int StudentId { get; set; }

        public Student(string firstName,
         string sureName,
         string lastName,
         string faculty,
         string specialnost,
         string major,
         string status,
         string facultyNumber,
         int course,
         int potok,
         int group)
        {

            this.firstName = firstName;
            this.sureName = sureName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.specialnost = specialnost;
            this.major = major;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.potok = potok;
            this.group = group;
            // diploma = "No diploma yet";
        }

        public Student()
        {

        }
    }
}
