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

namespace Movies
{
    /// <summary>
    /// Interaction logic for OpeningWindow.xaml
    /// </summary>
    public partial class OpeningWindow : Window
    {
        public OpeningWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click1(object sender, RoutedEventArgs e)
        {
            SignUp OpenSignUp = new SignUp();
            OpenSignUp.Show();
            this.Close();
        }

        private void Submit_Click2(object sender, RoutedEventArgs e)
        {
            LogIn OpenLogIn = new LogIn();
            OpenLogIn.Show();
            this.Close();
        }
    }
}
