using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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


namespace Expenslt
{
    /// <summary>
    /// Interaction logic for ExpenseltHom.xaml
    /// </summary>
    public partial class ExpenseltHom : Window, System.ComponentModel.INotifyPropertyChanged
    {
        public ExpenseltHom()
        {
            InitializeComponent();
            MainCaptionText = "View Expense Report";
            this.DataContext = this;
            LastChecked = DateTime.Now;
            PersonsChecked = new ObservableCollection<string>();

            People = new List<Person>()
            {
                new Person()
                {
                    Name = "Mike",
                    Department ="Legal",
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType="Lunch",ExpenseAmount= 50},
                        new Expense(){ExpenseType="Transportation",ExpenseAmount= 50}

                    }
                },
                 new Person()
                {
                    Name = "Lisa",
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType="Document Printing",ExpenseAmount= 50},
                        new Expense(){ExpenseType="Gift",ExpenseAmount= 125}

                    }
                },
                  new Person()
                {
                    Name = "Jhon",
                    Department ="Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType="Magazine Subscription",ExpenseAmount= 50},
                        new Expense(){ExpenseType="New Machine",ExpenseAmount= 600},
                        new Expense(){ExpenseType="Software",ExpenseAmount= 500}

                    }
                },
                   new Person()
                {
                    Name = "Mary",
                    Department ="Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType="Dinner",ExpenseAmount= 100}
                    }
                },
                    new Person()
                {
                    Name = "Theo",
                    Department ="Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType="Dinner",ExpenseAmount= 100}
                    }
                },
                    new Person()
                {
                    Name = "James",
                    Department ="Human Resources",
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType="Magazine Subscription",ExpenseAmount= 50},
                        new Expense(){ExpenseType="Lunch",ExpenseAmount= 60},
                        new Expense(){ExpenseType="Car payment",ExpenseAmount= 500}

                    }
                },
                     new Person()
                {
                    Name = "David",
                    Department ="Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ExpenseType="Magazine Subscription",ExpenseAmount= 50},
                        new Expense(){ExpenseType="New desk",ExpenseAmount= 100},
                        new Expense(){ExpenseType="Lunch",ExpenseAmount= 50}

                    }
                }

            };
        }
        public List<Person> People { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                }
            }
        }
        public string MainCaptionText { get; set; }

        public ObservableCollection<string> PersonsChecked
        { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ExpenseReport reportWindow = new ExpenseReport(peopleListBox.SelectedItem);
            reportWindow.Height = this.Height;
            reportWindow.Width = this.Width;
            reportWindow.Show();
        }

        private void plb_Change1(object sender, SelectionChangedEventArgs e)

        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add((peopleListBox.SelectedItem as Person).Name);
        }
    }
}
