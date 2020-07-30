using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerLibr
{
    public class Logger
    {
        static private List<string> activities = new List<string>();   //list used to store current session activities


        static public void AddActivity(string filename, string message, string action) //user provides file location a string that wants to be saved to the file 
                                                                                       //and an action on wich the entries can be retrieved later
        {                                                                                                                                                           //msg
            string activity = DateTime.Now + ";" + message + ";" + action + "\n"; // in our case the string that will be written to file should look like date;(role;username);action
            activities.Add(activity);               // adding current session activities lost upon program termination    
            if (File.Exists(filename) == true)      // check if file exists write or throw error
            {
                File.AppendAllText(filename, activity);
            }
            else
            {
                Console.WriteLine("Can`t write to file");
            }
        }

        static public void getCurrentSessionActivity()           // prints the contents of the activities list to the console;
        {
            StringBuilder builder = new StringBuilder();
            foreach (string activ in activities)
            {
                builder.Append(activ);
            }
            Console.WriteLine(builder.ToString());
        }

        static public void searchByAction(string filename, string action)
        {
            string[] lines = File.ReadAllLines(filename);                    // array in wich all lines in the file are stored
            foreach (string st in lines)              // we loop trough the array when an entry with the wanted action is found it is printed on the console
            {
                string[] line = st.Split(';'); //splitting string to find the action  we know that the messeage and action are split by ";"
                if (line.Length < 2) // if this  passes there are no more valid entries
                {
                    break;
                }
                if (action == line[3]) // if action is found in the written string it is written to the console
                {
                    Console.WriteLine(st);
                }
            }
        }

        static public void writeToDB(string action, string username, string serverName, string dbName) //making this a standalone function because writing to Db is not mandatory
        {
            Log log = new Log(action, DateTime.Now, username); // create new log object
            LogsContext context = new LogsContext(serverName, dbName);// works with diiferent servers and databases ... as a library Should
            context.Logs.Add(log); // add object to dbSet
            context.SaveChanges(); // changes saved to Database

        }
    }
}
