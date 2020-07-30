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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem();
            james.Content = "David";
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
        }

        private void btn_hello_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length < 2)
            {
                MessageBox.Show("Name must be at least 2 charecters long !");
            }
            else
            {
                string msg = "";
                int counter = 0;
                foreach (var item in MainGrid.Children)
                {
                    if (item is TextBox)
                    {
                        msg += ((TextBox)item).Text + " ";
                        counter++;
                    }
                    if (counter > 2)
                    {
                        break;
                    }
                }
                MessageBox.Show("Hello " + msg + " nice to see you working with WPF! ");
            }

        }

        private void factBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(numberTxt.Text);
            double result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            MessageBox.Show("Factorial of " + number + " is " + result);
        }

        private void powBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(numberTxt.Text);
            double number1 = Convert.ToDouble(powerTxt.Text);
            double result = Math.Pow(number, number1);

            MessageBox.Show(number + " to the power of " + number1 + " is " + result);
        }

        private void waitBeforeClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string message = "Are you sure you want to close ?";
            string caption = "Closing...";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result;
            result = MessageBox.Show(message, caption, buttons, MessageBoxImage.Exclamation);

            if (Convert.ToString(result) == "No")
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyMessage another = new MyMessage();
            another.Show();
            TextBlock1.Text = DateTime.Now.ToString();
        }

        private void greetBtn_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }
    }
}
