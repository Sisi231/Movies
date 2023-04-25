using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
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
    /// Interaction logic for MyList.xaml
    /// </summary>
    public partial class MyList : Window
    {
        public string AccountHolder;
        public MyList(string user)
        {
            InitializeComponent();
            AccountHolder = user;
            fill();
        }
        void fill()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-9B7GMJ6\SQLEXPRESS; Initial Catalog= Movies; Integrated Security=True");
            try
            {

                sqlCon.Open();
                String query = "Select movieName from MyList Where username ='" + AccountHolder + "'";
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
