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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public string username;
        public Menu(string AccountHolder)
        {
            username = AccountHolder;
            InitializeComponent();
        }

        private void Submit_Click1(object sender, RoutedEventArgs e)
        {
            Account OpenAccount = new Account(username);
            OpenAccount.Show();
            this.Close();
        }

        private void Submit_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_Click3(object sender, RoutedEventArgs e)
        {
            SearchMovieByGenre OpenSearchGenre = new SearchMovieByGenre(username);
            OpenSearchGenre.Show();
            this.Close();
        }

        private void Submit_Click4(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_Click5(object sender, RoutedEventArgs e)
        {

        }
    }
}
