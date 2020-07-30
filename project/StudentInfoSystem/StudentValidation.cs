using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public static Student IsThereStudent(User userToCheck)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student result = (from st in context.Students where st.facultyNumber == userToCheck.facultyNumber select st).First();
            return result;

            //return null; // if it gets here that means no such student is found and the function will return null 

        }


    }
}
