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
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            txtActor.Text = textInfo.ToTitleCase(txtActor.Text);
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=Movies; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
                string query = $"SELECT COUNT(*) FROM Credits Where name='{txtActor.Text}'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                int rowCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (rowCount == 0)
                {
                    MessageBox.Show("No such actor!");
                }
                else
                {
                    AllActors OpenMovie = new AllActors(AccountHolder, txtActor.Text);
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
    }
}
