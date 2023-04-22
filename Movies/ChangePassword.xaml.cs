using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public string username;
        public ChangePassword(string AccountHolder)
        {
            InitializeComponent();
            username = AccountHolder;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (NewPasswordBox.Password.Length < 10 || NewPasswordBox.Password.Length > 10)
            {
                MessageBox.Show("Your password should be at least 10 symbols long! Try again");
            }
            else if (!(NewPasswordBox.Password == ReNewPasswordBox.Password))
            {
                MessageBox.Show("The passwords don't match!Try again.");
            }
            else
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog=Movies; Integrated Security=True");

                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    string query = "Update SignUpTable set Password = '"+NewPasswordBox.Password+"' Where Username='"+username+"'and Password ='"+ CurrentPassword.Password  + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password successfully changed!");
                    Account OpenAccount = new Account(username);
                    OpenAccount.Show();
                    this.Close();
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu OpenMenu = new Menu(username);
            OpenMenu.Show();
            this.Close();
        }
    }
}
