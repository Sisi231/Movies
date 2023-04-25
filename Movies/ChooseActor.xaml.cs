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
    /// Interaction logic for ChooseActor.xaml
    /// </summary>
    public partial class ChooseActor : Window
    {
        public string AccountHolder;

        public ChooseActor(string user)
        {
            InitializeComponent();
            AccountHolder = user;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu = new Menu(AccountHolder);
            OpenMenu.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            AllActors OpenMovie = new AllActors(AccountHolder, txtActor.Text);
            OpenMovie.Show();
            this.Close();
        }
    }
}
