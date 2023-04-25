using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for Movie.xaml
    /// </summary>
    public partial class Movie : Window
    {
        public string AccountHolder;
        public string MovieTitle;
        public Movie(string user, string movieTitle)
        {
            InitializeComponent();
            AccountHolder = user;
            MovieTitle = movieTitle;
            fill();
        }
        void fill()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=Movies; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT title, type, release_year, age_certification, runtime, genres, production_countries, seasons, description FROM Titles Where title = '" + MovieTitle + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                dr.Read();
                txtTitle.Text = dr.GetString(0);
                string numberOfSeasons = dr.IsDBNull(7) ? "unknown" : Convert.ToString(dr["seasons"]);
                string TypeOfMovie = dr.IsDBNull(1) ? "unknown" : Convert.ToString(dr["type"]);
                if (TypeOfMovie == "MOVIE") txtType.Text = TypeOfMovie;
                else txtType.Text = " " + TypeOfMovie + " - " +numberOfSeasons+ " seasons";
                txtYear.Text = dr.IsDBNull(2)? "unknown": Convert.ToString(dr["release_year"]);
                txtAge.Text = dr.IsDBNull(3) ? "unknown" : Convert.ToString(dr["age_certification"]);
                txtTime.Text = dr.IsDBNull(4) ? "unknown" : Convert.ToString(dr["runtime"]);
                txtGenres.Text = dr.IsDBNull(5) ? "unknown" : Convert.ToString(dr["genres"]);
                txtCountry.Text = dr.IsDBNull(6) ? "unknown" : Convert.ToString(dr["production_countries"]);
                txtDescription.Text = dr.IsDBNull(8) ? "unknown" : Convert.ToString(dr["description"]);
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
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Ratings OpenRatings = new Ratings(AccountHolder, MovieTitle);
            OpenRatings.Show();
            this.Close();
        }

        private void Submit_Click_1(object sender, RoutedEventArgs e)
        {
            Actors OpenActors = new Actors(AccountHolder, MovieTitle);
            OpenActors.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu = new Menu(AccountHolder);
            OpenMenu.Show();
            this.Close();
        }

        private void Submit_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=Movies; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
                string query = $"Select Count(*) from MyList where username = {AccountHolder} and movieName = {MovieTitle}";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                int rowCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (rowCount == 0)
                {
                    string Secondquery = $"Insert Into MyList(username, movieName) values('{AccountHolder}', '{MovieTitle}')";
                    SqlCommand sqlCmd1 = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                }
                else return;
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
    }
}
