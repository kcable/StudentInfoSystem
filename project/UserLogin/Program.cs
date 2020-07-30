using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {

        public static void showError(string err)
        {
            Console.WriteLine("!!! " + err + " !!!");
        }
        static void Main(string[] args)

        {
            string name;
            string pass;

            Console.WriteLine("Enter username: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            pass = Console.ReadLine();
            LoginValidation validator = new LoginValidation(name, pass, showError);


            User nullUser = new User();
            if (validator.ValidateUserInput(ref nullUser))
            {
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMUS: Console.WriteLine("You are logged in as ANONYMUS"); break;
                    case UserRoles.ADMIN: Console.WriteLine("You are logged in as ADMIN"); break;
                    case UserRoles.INSPECTOR: Console.WriteLine("You are logged in as INSPECTOR"); break;
                    case UserRoles.PROFESSOR: Console.WriteLine("You are logged in as PROFESSOR"); break;
                    case UserRoles.STUDENT: Console.WriteLine("You are logged in as STUDENT"); break;
                }
                Console.WriteLine("USERROLE: " + nullUser.userRole); ;
                Console.WriteLine("Name " + nullUser.userName);
                Console.WriteLine("FACNUM: " + nullUser.facultyNumber);
                Console.WriteLine("Password: " + nullUser.password);
            }
            else
            {
                Console.WriteLine("Validation error");
            }

            if (LoginValidation.currentUserRole == UserRoles.ADMIN)
            {
                bool done = false;
                while (!done)
                {
                    Console.WriteLine("Choose an Option: ");
                    Console.WriteLine("0 Exit");
                    Console.WriteLine("1 Change user role ");
                    Console.WriteLine("2 Change user active date ");
                    Console.WriteLine("3 List of Users");
                    Console.WriteLine("4 Show activities");
                    Console.WriteLine("5 Show current Session activities");
                    Console.WriteLine("6 Search log by action");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "0": Console.WriteLine("Exiting..."); done = true; break;
                        case "1":
                            Console.WriteLine("Please enter userID you wish to change");
                            int userId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please enter new role NUMBER ");
                            int num = int.Parse(Console.ReadLine());
                            UserData.AssignUserRole(userId, num);
                            break;
                        case "2":
                            Console.WriteLine("Please enter username you wish to change");
                            string name2 = Console.ReadLine();
                            Console.WriteLine("Please enter new Date ");
                            DateTime date1 = Convert.ToDateTime(Console.ReadLine());
                            UserData.SetUserActiveTo(name2, date1);
                            break;
                        case "3":
                            UserData.ShowUsers();
                            break;

                        case "4":
                            if (File.Exists("C:/Users/shark/Desktop/TU]/PS_39_Krustev/libtest.txt") == true)
                            {
                                Console.Write(File.ReadAllText("C:/Users/shark/Desktop/TU]/PS_39_Krustev/libtest.txt"));
                            }
                            break;

                        case "5":
                            LoggerLibr.Logger.getCurrentSessionActivity();
                            //Logger.getCurrentSessionActivity();
                            break;
                        case "6":
                            Console.WriteLine("Enter action : ");
                            string action = Console.ReadLine();
                            LoggerLibr.Logger.searchByAction("C:/Users/shark/Desktop/TU]/PS_39_Krustev/libtest.txt", action);
                            //Logger.getCurrentSessionActivity();
                            break;

                        default: Console.WriteLine("No such choice! "); break;
                    }
                }
            }


            Console.ReadLine();
        }
    }
}
