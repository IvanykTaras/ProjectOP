using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Pexels
using PexelsDotNetSDK.Api;
using Newtonsoft.Json;
using System.Data.SqlClient;


namespace ProjectOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_Clear(object sender, RoutedEventArgs e)
        {
            inputName.Clear();
            inputPassword.Clear();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            ManageUsers window = new ManageUsers();
            ManageCustomers window2 = new ManageCustomers();
            window2.Show();
            this.Close();
        }
    }
}
