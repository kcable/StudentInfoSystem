using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    public class Logger
    {
        static private List<string> activities = new List<string>();

        static public void AddActivity(string activity)
        {
            string file = "C:/Users/shark/Desktop/TU]/PS_39_Krustev/test.txt";
            string toAdd = DateTime.Now + ";" + LoginValidation.currentUserRole + ";" + LoginValidation.currentUserName + ";" + activity + "\n";
            activities.Add(toAdd);
            if (File.Exists(file) == true)
            {
                File.AppendAllText(file, toAdd);
            }
            else
            {
                Console.WriteLine("Can`t write to file");
            }

            Log log = new Log(activity, DateTime.Now, LoginValidation.currentUserName);
            LogsContex context = new LogsContex();
            context.Logs.Add(log);
            context.SaveChanges();
        }

        static public void getCurrentSessionActivity()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string activ in activities)
            {
                builder.Append(activ);
            }
            Console.WriteLine(builder.ToString());

        }
    }
}
