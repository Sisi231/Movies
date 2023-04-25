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
    /// Interaction logic for SearchByMovieName.xaml
    /// </summary>
    public partial class SearchByMovieName : Window
    {
        public string AccountHolder;
        public SearchByMovieName(string user)
        {
            InitializeComponent();
            AccountHolder = user;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Movie OpenMovie = new Movie(AccountHolder, txtMovie.Text);
            OpenMovie.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu = new Menu(AccountHolder);
            OpenMenu.Show();
            this.Close();
        }
    }
}
