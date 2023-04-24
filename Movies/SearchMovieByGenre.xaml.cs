using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for SearchMovieByGenre.xaml
    /// </summary>
    public partial class SearchMovieByGenre : Window
    {
        public string AccountHolder;
        public SearchMovieByGenre(string user)
        {
            InitializeComponent();
            AccountHolder = user;
            fill_combo1();
        }
        
        void fill_combo1()
        {
            string[] genres = new string[] {"comedy", "drama", "family", "romance","animation", "documentation","action","scifi","crime","european", "thriller","music","history","war","fantasy","sport","reality","horror" };
            for (int i = 0; i < genres.Length; i++)
            {
                comboBox.Items.Add(genres[i]);
                comboBox1.Items.Add(genres[i]);
                comboBox2.Items.Add(genres[i]);
            }

        }
        public string[] Genre = new string[3];
        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Genre[0] = comboBox.Items[comboBox.SelectedIndex].ToString();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            ChooseMovie OpenChooseMovie = new ChooseMovie(AccountHolder, Genre);
            OpenChooseMovie.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu1 = new Menu(AccountHolder);
            OpenMenu1.Show();
            this.Close();
        }
        public string ChoosenGenre2;

        private void comboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            Genre[1] = comboBox.Items[comboBox.SelectedIndex].ToString();
        }
        public string ChoosenGenre3;

        private void comboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            Genre[2] = comboBox.Items[comboBox.SelectedIndex].ToString();
        }
    }
}
