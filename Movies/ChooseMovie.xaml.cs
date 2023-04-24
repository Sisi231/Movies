using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for ChooseMovie.xaml
    /// </summary>
    public partial class ChooseMovie : Window
    {
        public string Accountholder;
        public string[] genres = new string[3]; 
        public ChooseMovie(string user, string[]movieGenres)
        {
            InitializeComponent();
            Accountholder = user;
            genres = movieGenres;
            fill();
        }
        void fill()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=Movies; Integrated Security=True");
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (genres[i] != null) count++;
            }
            string[] genresEntered = new string[count];
            for (int i = 0, j = 0; i < 3; i++, j++)
            {
                if (genres[i] != null) genresEntered[j] = genres[i];
                else j--;
            }
            string stringGenres = "";
            for (int i = 0; i < genresEntered.Length; i++)
            {
                stringGenres += $"{genresEntered[i]} ";
            }
            try
            {
                
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
                string query ="";
                if (genresEntered.Length == 0) MessageBox.Show("Select at least one genre");
                if (genresEntered.Length == 1) query = $"Select title from Titles Where genres like '%{genresEntered[0]}%'";
                if (genresEntered.Length == 2) query = $"Select title from Titles Where genres like '%{genresEntered[0]}%' and genres like '%{genresEntered[1]}%'";
                if (genresEntered.Length == 3) query = $"Select title from Titles Where genres like '%{genresEntered[0]}%' and genres like '%{genresEntered[1]}%' and genres like '%{genresEntered[2]}%'";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    var SubjectName = dr.GetValue(1);
                    comboBox.Items.Add(SubjectName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Movies OpenMovie = new Movies(movieChosen);
            //OpenMovie.Show();
            //this.Close();
        }
        public string movieChosen;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            movieChosen = comboBox.Items[comboBox.SelectedIndex].ToString();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
