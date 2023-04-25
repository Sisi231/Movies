using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Movies
{
    /// <summary>
    /// Interaction logic for Actors.xaml
    /// </summary>
    public partial class Actors : Window
    {
        public string AccountHolder;
        public string MovieTitle;
        public Actors(string user, string Movie)
        {
            InitializeComponent();
            AccountHolder = user;
            MovieTitle = Movie;
            fill();
        }
        void fill()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog= Movies; Integrated Security=True");
            try
            {

                sqlCon.Open();
                String query = "Select id from Titles Where title='" + MovieTitle + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                dr.Read();
                string MovieID = Convert.ToString(dr["id"]);
                dr.Close();
                string newQuery = $"Select name, character from Credits Where id='{MovieID}' and role='ACTOR'";
                SqlCommand sqlCmd1 = new SqlCommand(newQuery, sqlCon);
                sqlCmd1.ExecuteNonQuery();
                SqlDataAdapter word = new SqlDataAdapter(sqlCmd1);
                DataTable dt = new DataTable();
                word.Fill(dt);
                DataGrid1.ItemsSource = dt.DefaultView;
                word.Update(dt);
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu = new Menu(AccountHolder);
            OpenMenu.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Movie OpenMovie = new Movie(AccountHolder, MovieTitle);
            OpenMovie.Show();
            this.Close();
        }
    }
}
