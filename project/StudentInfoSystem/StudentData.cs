using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        public static List<Student> testStudents
        {
            get
            {
                ResetData();
                return _testStudents;

            }
            private set { }
        }

        private static List<Student> _testStudents;
        private static void ResetData()
        {
            if (_testStudents == null)
            {
                _testStudents = new List<Student>();
                _testStudents.Add(new Student("Pesho", "Petrov", "Petkov", "FKST", "KSI", "bachelor", "zapisan", "10001", 1, 1, 30));
                _testStudents.Add(new Student("Gosho", "Ivanov", "Georgiev", "FKST", "KSI", "bachelor", "zapisan", "10002", 1, 1, 30));
                _testStudents.Add(new Student("Ivan", "Petrov", "Petkov", "FKST", "KSI", "bachelor", "zapisan", "1000", 1, 1, 30));
            }

        }


    }
}
