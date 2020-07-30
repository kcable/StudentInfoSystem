using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace UserLogin
{
    public class LoginValidation
    {
        private string username;
        private string password;
        private string error;
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError errorMsg;


        public LoginValidation(string name, string pass, ActionOnError er)
        {
            this.username = name;
            this.password = pass;
            this.errorMsg = er;

        }

        private int CountLogins(string username)
        {
            int counter = 0;
            DateTime date1;
            //string[] lines = File.ReadAllLines("C:/Users/shark/Desktop/TU]/PS_39_Krustev/test.txt");
            string[] lines = File.ReadAllLines("C:/Users/shark/Desktop/TU]/PS_39_Krustev/libtest.txt");
            // Console.WriteLine(lines);
            foreach (string str in lines)
            {
                // Console.WriteLine(str);
                string[] nameCheck = str.Split(';');
                if (nameCheck.Length < 2)
                {
                    break;
                }
                if (username == nameCheck[2])
                {
                    date1 = Convert.ToDateTime(nameCheck[0]);
                    if (date1.Day >= DateTime.Now.Day - 2 && nameCheck[3] == "Login successful!")
                    {
                        counter++;
                    }
                }

            }

            return counter;
        }

        public static UserRoles currentUserRole { get; private set; }
        public static string currentUserName { get; private set; }
        public bool ValidateUserInput(ref User u1)
        {

            //u1.facultyNumber = UserData.testUser.facultyNumber;
            //u1.password = UserData.testUser.password;
            //u1.userName = UserData.testUser.userName;
            //u1.userRole = UserData.testUser.userRole;
            currentUserRole = (UserRoles)0;
            currentUserName = "";
            if (this.username.Equals(String.Empty) || this.username.Length < 5)
            {
                error = " Username restrictions not met ";
                errorMsg(error);
                return false;
            }

            if (password.Equals(String.Empty) || this.password.Length < 5)
            {
                error = "Password restrictions not met";
                errorMsg(error);
                return false;
            }


            User temp = UserData.IsUserPassCorrect(this.password, this.username);
            if (temp == null)
            {
                error = "User-Password combination not found";
                errorMsg(error);
                return false;
            }
            else
            {
                u1 = temp;
                currentUserRole = (UserRoles)u1.userRole;
                currentUserName = u1.userName;

                Console.WriteLine("User: " + currentUserName + " has logged in " + CountLogins(currentUserName) + " times in the last 2 days");

                //using library here
                LoggerLibr.Logger.AddActivity("C:/Users/shark/Desktop/TU]/PS_39_Krustev/libtest.txt",
                currentUserRole + ";" + currentUserName, "Login successful!");
                //                                                     my local sql server name and db name
                LoggerLibr.Logger.writeToDB("Login", currentUserName, "DESKTOP-00DGOP9", "StudentInfoDatabase");

                //Logger.AddActivity("Login successful!"); old class

            }
            return true;
        }
    }
}
