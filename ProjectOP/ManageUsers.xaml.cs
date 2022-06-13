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
using System.Data.SqlClient;

namespace ProjectOP
{
    /// <summary>
    /// Logika interakcji dla klasy ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : Window
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\khrys\OneDrive\Dokumenty\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Label_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            try
            {
            
                Conn.Open();
                SqlCommand command = new SqlCommand("insert into UserTb1 values('"+ unameTB.Text + "','"+ufullnameTB.Text+"', '"+ upasswordTB.Text+"', '"+ utelephoneTB.Text+"');",Conn);
                command.ExecuteNonQuery();
                MessageBox.Show("User successfully added");
                Conn.Close();
            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
