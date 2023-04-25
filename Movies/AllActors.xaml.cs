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
    /// Interaction logic for AllActors.xaml
    /// </summary>
    public partial class AllActors : Window
    {
        public string AccountHolder;
        public string Actor;
        public AllActors(string user, string actorName)
        {
            InitializeComponent();
            AccountHolder = user;
            Actor = actorName;
            fill();
        }
        void fill()
        {
            txtActor.Text = Actor;
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog= Movies; Integrated Security=True");
            try
            {

                sqlCon.Open();
                String query = "Select title, character from MoviesAndCharacters Where name ='" + Actor + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                SqlDataAdapter word = new SqlDataAdapter(sqlCmd);
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
    }
}
