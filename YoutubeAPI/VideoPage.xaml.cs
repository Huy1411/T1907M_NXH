using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YoutubeAPI.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace YoutubeAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoPage : Page
    {
        Model.Video video;

        public VideoPage()
        {
            this.InitializeComponent();
        }

       

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    video = e.Parameter as Model.Video;

                  //  Google.Apis.YouTube.v3.YouTubeService youTube = new YouTubeService();
                    
                    //YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
                    //{
                    //    ApplicationName = "youtube",
                    //    ApiKey = "AIzaSyDBf8bq5AKUSHfF_CF0eeZ2RCLzyfmOi5s",
                    //});
                    //SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
                    //listRequest.Q = "Loeb Pikes Peak";
                    //listRequest.MaxResults = 5;
                    //listRequest.Type = "video";
                    //SearchListResponse resp = listRequest.Execute();
                    //foreach (SearchResult result in resp.Items)
                    //{
                    //    Console.WriteLine(result.Snippet.Title);
                    //}

                      var Url = await YouTube.GetVideoUriAsync(video.Id, YouTubeQuality.Quality1080P);

                    Player.Source = Url.Uri;

                }
                else
                {
                    MessageDialog message = new MessageDialog("You are not connected to Internet");
                    await message.ShowAsync();
                    this.Frame.GoBack();
                }
            }
            catch { }
            base.OnNavigatedTo(e);
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), new object());
        }
    }
}
