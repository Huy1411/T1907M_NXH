using NetWork.Models;
using static NetWork.Models.NetWorkJson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using static NetWork.Models.NetWorkJson.Content;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NetWork
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        public MainPage()
        {
            this.InitializeComponent();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                News myPage = await NetWorkJson.GetNetWorkJson();

                string image = String.Format(myPage.image);
                ImageResult.Source = new BitmapImage(new Uri(image, UriKind.Absolute));
                DateResult.Text = myPage.date;
                TitleResult.Text = myPage.title;
                string description = myPage.content.description;
                ContentResult.Text = description;
            }
            catch (Exception)
            { 

            }
                
        }
    }
}
