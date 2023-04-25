using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Movies
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        public string username;
        public Account(string AccountHolder)
        {
            InitializeComponent();
            username = AccountHolder;
            fill_Data();
        }
        void fill_Data()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=Movies; Integrated Security=True");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = $"SELECT Username, Email FROM SignUpTable Where Username = '{username}'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                dr.Read();
                txtUsername.Text = dr.GetString(0);
                txtEmail.Text = dr.GetString(1);
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
            Menu OpenMenu = new Menu(username);
            OpenMenu.Show();
            this.Close();
        }

        private void Submit_Click2(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu = new Menu(username);
            OpenMenu.Show();
            this.Close();
        }

        private void Submit_Click1(object sender, RoutedEventArgs e)
        {
            ChangePassword OpenChangePassword = new ChangePassword(username);
            OpenChangePassword.Show();
            this.Close();
        }
    }
}
