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

namespace ProjectOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        private async void DownloadJsonData()
        {

        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            PexelsClient client = new PexelsClient("YOUR_API_KEY");
            var photos = await client.FeaturedCollectionsAsync(1,3);
            if (photos != null) { 
                Log.Text =  Convert.ToString(photos.totalResults);               
            }
        }
    }
}
