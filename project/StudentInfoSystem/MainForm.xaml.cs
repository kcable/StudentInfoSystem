using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using UserLogin;

namespace StudentInfoSystem
{

    public partial class MainForm : Window
    {
        User tempuser;
        public List<string> StudStatusChoices { get; set; }

        private void FillStudChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }


        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            return countStudents <= 0 ? true : false;
        }


        private bool TestDiplomaIfEmpty()
        {
            DiplomaContext context = new DiplomaContext();
            IEnumerable<Diploma> queryDiploma = context.Diplomas;
            int countDiploma = queryDiploma.Count();
            return countDiploma <= 0 ? true : false;
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.testStudents)
            {
                context.Students.Add(st);
            }

            context.SaveChanges();
        }

        public void setDiplomas()
        {
            if (TestDiplomaIfEmpty())
            {
                DiplomaContext context = new DiplomaContext();
                foreach (Student st in StudentData.testStudents)
                {
                    context.Diplomas.Add(new Diploma(st.facultyNumber));
                }

                context.SaveChanges();
            }
        }

        public MainForm(User u1)
        {
            InitializeComponent();

            setDiplomas();
            // CopyTestStudents();
            tempuser = u1;

            DataContext = new MainWindowVM(tempuser);
            FillStudChoices();
            // this.DataContext = this;


        }

        private void clearAll()
        {

            foreach (TextBox item in personalInfoGrid.Children)
            {
                item.Text = "";
            }

            foreach (TextBox item in studentInfoGrid.Children)
            {
                item.Text = "";
            }
        }

        private void enableAll()
        {
            foreach (TextBox item in personalInfoGrid.Children)
            {
                item.IsEnabled = true;
            }

            foreach (TextBox item in studentInfoGrid.Children)
            {
                item.IsEnabled = true;
            }
        }

        private void disableAll()
        {
            foreach (TextBox item in personalInfoGrid.Children)
            {
                item.IsEnabled = false;
            }

            foreach (TextBox item in studentInfoGrid.Children)
            {
                item.IsEnabled = false;
            }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            disableAll();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            enableAll();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
                MessageBox.Show("True");
            }
            else
            {
                MessageBox.Show("False");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DiplomaContext context = new DiplomaContext();
            Diploma result = (from dp in context.Diplomas where dp.student == tempuser.facultyNumber select dp).First();
            DialogDipl dialog = new DialogDipl("Vuvedete tema", "Web sait");
            if (dialog.ShowDialog() == true)
            {
                result.topic = dialog.Answer;
            }
            diplomaTxt.Text = result.topic;
            context.SaveChanges();                       // promenite se zapazvat v bazata danni mojete da runete query
        }


    }
}
