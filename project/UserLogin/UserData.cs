using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        public static List<User> testUsers
        {
            get
            {
                ResetUserData();
                return _testUsers;
            }

            set { }
        }
        private static List<User> _testUsers;
        private static void ResetUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();
                _testUsers.Add(new User(1, "admin", "admin1", "1000", DateTime.Now, DateTime.MaxValue));
                _testUsers.Add(new User(4, "student1", "student1", "10001", DateTime.Now, DateTime.MaxValue));
                _testUsers.Add(new User(4, "student2", "student2", "10002", DateTime.Now, DateTime.MaxValue));


            }
            // populva bazata danni samo ako tq e prazna 
            UserContext context = new UserContext();
            IEnumerable<User> queryUsers = context.Users;
            if (queryUsers.Count() <= 0)
            {
                foreach (User user in _testUsers)
                {
                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }

        public static User IsUserPassCorrect(string pass, string name)
        {
            UserContext context = new UserContext();
            User result = (from user in context.Users where user.userName == name && user.password == pass select user).FirstOrDefault();
            return result;
        }

        public static void SetUserActiveTo(string username, DateTime activeDate)
        {
            UserContext context = new UserContext();
            User usr = (from user in context.Users where user.userName == username select user).First();
            usr.ValidTo = activeDate;
            context.SaveChanges();


            //Logger.AddActivity("Changed active date for " + username);
            LoggerLibr.Logger.AddActivity("C:/Users/shark/Desktop/TU]/PS_39_Krustev/libtest.txt",
                LoginValidation.currentUserRole + ";" + LoginValidation.currentUserName, "Changed active date for " + username);

            LoggerLibr.Logger.writeToDB("Changed date for " + username, LoginValidation.currentUserName, "DESKTOP-00DGOP9", "StudentInfoDatabase");
        }

        public static void ShowUsers()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryUser = context.Users;
            foreach (User us in queryUser)
            {
                Console.WriteLine(us.ToString());
            }
        }

        public static void AssignUserRole(int userid, int newRole)
        {


            UserContext context = new UserContext();

            User usr =
            (from u in context.Users
             where u.UserId == userid
             select u).First();
            usr.userRole = newRole;
            context.SaveChanges();


        }
    }
}
