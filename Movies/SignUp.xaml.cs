using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length < 10 || PasswordBox.Password.Length > 10)
            {
                MessageBox.Show("Your password should be at least 10 symbols long! Try again");
            }
            else if (txtFirstName.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (txtLastName.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (txtUsername.Text.Equals(""))
            {
                MessageBox.Show("You cannot leave this field empty!");
            }
            else if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("You cannot have an email without '@'!");
            }
            else if (!(PasswordBox.Password == RePasswordBox.Password))
            {
                MessageBox.Show("The passwords don't match!Try again.");
            }
            else
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog= Movies; Integrated Security=True");

                try
                {


                    //opening the connection to the db 

                    sqlCon.Open();

                    //Build our actual query 

                    string query = "INSERT INTO SignUpTable([FirstName],[LastName],[Email],[Username],[Password])values ('" + this.txtFirstName.Text + "','" + this.txtLastName.Text + "','" + this.txtEmail.Text + "','" + this.txtUsername.Text + "','" + this.PasswordBox.Password + "') ";

                    //Establish a sql command

                    SqlCommand cmd = new SqlCommand(query, sqlCon);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully saved");

                    LogIn lg = new LogIn();
                    lg.Show();
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
            OpeningWindow OpenOpening = new OpeningWindow();
            OpenOpening.Show();
            this.Close();
        }
    }
}
