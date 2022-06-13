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
using System.Data;

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
            catch (Exception exeption)
            {

                MessageBox.Show("Some problems with adding new user!!!");
            }
        }

        void showAllUsers() {
            Conn.Open();
            string myQuery = "select * from UserTb1";
            SqlDataAdapter da = new SqlDataAdapter(myQuery, Conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds,"Users");
            DataTable usersTable = ds.Tables["Users"];


            var HeaderBlock1 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Name", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000")  }
            };
            var HeaderBlock2 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "FullName" , Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock3 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Password" , Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock4 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Phone" , Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var stackHeader = new StackPanel() { Orientation = Orientation.Horizontal, };
            stackHeader.Children.Add(HeaderBlock1);
            stackHeader.Children.Add(HeaderBlock2);
            stackHeader.Children.Add(HeaderBlock3);
            stackHeader.Children.Add(HeaderBlock4);
            usersStackTable.Children.Add(stackHeader);


            foreach (DataRow row in usersTable.Rows) {
                
                var block1 = new Border() { BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"), BorderThickness = new Thickness(1), Width = 100,
                    Child = new TextBlock() {Text = (string)row[0] } };
                var block2 = new Border() { BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"), BorderThickness = new Thickness(1), Width = 100,
                    Child = new TextBlock() {Text = (string)row[1] } };
                var block3 = new Border() { BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"), BorderThickness = new Thickness(1), Width = 100,
                    Child = new TextBlock() {Text = (string)row[2] } };
                var block4 = new Border() { BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"), BorderThickness = new Thickness(1), Width = 100,
                    Child = new TextBlock() {Text = (string)row[3] } };
                var stack = new StackPanel() { Orientation = Orientation.Horizontal};
                stack.Children.Add(block1);
                stack.Children.Add(block2);
                stack.Children.Add(block3);
                stack.Children.Add(block4);
                usersStackTable.Children.Add(stack);
            }
            Conn.Close();
            
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            usersStackTable.Children.Clear();
            showAllUsers();
        }
    }
}
