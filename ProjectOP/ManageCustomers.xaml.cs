
    


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
    /// Logika interakcji dla klasy ManageCustomers.xaml
    /// </summary>
    public partial class ManageCustomers : Window
    {
        public ManageCustomers()
        {
            InitializeComponent();
        }
    



        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\khrys\OneDrive\Dokumenty\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        bool emptyChecker()
        {
            if (customerNameTB.Text == String.Empty || customerPhoneTB.Text == String.Empty || custoemerIdTB.Text == String.Empty)
            {
                MessageBox.Show("Ops some input is empty");
                return false;
            }


            return true;
        }

        private void Label_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            try
            {

                if (emptyChecker())
                {

                    Conn.Open();
                    SqlCommand command = new SqlCommand("insert into CustomerTb1 values('" + custoemerIdTB.Text + "','" + customerNameTB.Text + "', '" + customerPhoneTB.Text + "');", Conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("User successfully added");
                    Conn.Close();
                }

            }
            catch (Exception exeption)
            {

                MessageBox.Show("Some problems with adding new user!!!");
            }
        }

        void showAllCustomers()
        {
            Conn.Open();
            string myQuery = "select * from CustomerTb1";
            SqlDataAdapter da = new SqlDataAdapter(myQuery, Conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds, "Cutomers");
            DataTable usersTable = ds.Tables["Cutomers"];


            var HeaderBlock1 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "ID", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock2 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Name", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            var HeaderBlock3 = new Border()
            {
                BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                BorderThickness = new Thickness(1),
                Width = 100,
                Child = new TextBlock() { Text = "Phone", Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000") }
            };
            
            var stackHeader = new StackPanel() { Orientation = Orientation.Horizontal, };
            stackHeader.Children.Add(HeaderBlock1);
            stackHeader.Children.Add(HeaderBlock2);
            stackHeader.Children.Add(HeaderBlock3);
            
            customersStackTable.Children.Add(stackHeader);


            foreach (DataRow row in usersTable.Rows)
            {

                var block1 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = (string)row[0] }
                };
                var block2 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = (string)row[1] }
                };
                var block3 = new Border()
                {
                    BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#000"),
                    BorderThickness = new Thickness(1),
                    Width = 100,
                    Child = new TextBlock() { Text = (string)row[2] }
                };
                
                var stack = new StackPanel() { Orientation = Orientation.Horizontal };
                stack.Children.Add(block1);
                stack.Children.Add(block2);
                stack.Children.Add(block3);
                
                customersStackTable.Children.Add(stack);
            }
            Conn.Close();

        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            customersStackTable.Children.Clear();
            showAllCustomers();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (customerPhoneTB.Text == string.Empty)
            {
                MessageBox.Show("To delete user u need enter only Phone.");
            }
            else
            {
                try
                {
                    Conn.Open();
                    string myquery2 = "select * from CustomerTb1";
                    SqlDataAdapter da = new SqlDataAdapter(myquery2, Conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(da);
                    var ds = new DataSet();
                    da.Fill(ds, "Customer");
                    DataTable usersTable = ds.Tables["Customer"];
                    bool isReal = false;
                    foreach (DataRow row in usersTable.Rows)
                    {
                        if ((string)row["customerPhone"] == customerPhoneTB.Text) isReal = true;
                    }
                    Conn.Close();

                    if (isReal)
                    {
                        Conn.Open();
                        string myquery = "delete from CustomerTb1 where customerPhone='" + customerPhoneTB.Text + "'";
                        SqlCommand command = new SqlCommand(myquery, Conn);
                        command.ExecuteNonQuery();
                        MessageBox.Show("User successfully deleted");
                        Conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Phone value pls try again.");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Some problems with deleting or user doesnt exist!!!");
                }
            }
        }

        private void Home(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}

