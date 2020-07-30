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
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static void showError(string err)
        {
            MessageBox.Show(err);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            LoginValidation validator = new LoginValidation(username.Text, password.Password, showError);
            User temp = new User();
            if (validator.ValidateUserInput(ref temp) == true)
            {
                MainForm another = new MainForm(temp);
                another.Show();
                this.Close();
            }



        }
    }
}
