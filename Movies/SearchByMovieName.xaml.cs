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
using System.Globalization;
using System.Data.SqlClient;
using System.Data;


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
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            txtMovie.Text = textInfo.ToTitleCase(txtMovie.Text);
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=Movies; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
                string query = $"SELECT COUNT(*) FROM Titles Where title='{txtMovie.Text}'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                int rowCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (rowCount == 0)
                {
                    MessageBox.Show("No such movie!");
                }
                else
                {
                    Movie OpenMovie = new Movie(AccountHolder, txtMovie.Text);
                    OpenMovie.Show();
                    this.Close();
                }
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
    }
}
