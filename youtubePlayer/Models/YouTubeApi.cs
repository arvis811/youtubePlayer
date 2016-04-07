using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System.IO;
using System.Threading;
using System.Web;

namespace youtubePlayer.Models
{
    public class YouTubeApi
    {
        public static YouTubeService ytService = Auth();

        public static YouTubeService Auth()
        {
            UserCredential creds;
            using (var stream = new FileStream(HttpRuntime.AppDomainAppPath + "youtube_client_secret.json", FileMode.Open, FileAccess.Read))
            {
                creds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { YouTubeService.Scope.YoutubeReadonly },
                        "user",
                        CancellationToken.None,
                        new FileDataStore("YouTubeAPI")
                        ).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creds,
                ApplicationName = "youtubePlayer"
            });
            return service;
        }
        public static void GetVideoInfo(YouTubeVideo video)
        {
            var videoRequest = ytService.Videos.List("snippet");
            videoRequest.Id = video.id;

            var response = videoRequest.Execute();
            if (response.Items.Count > 0)
            {
                video.title = response.Items[0].Snippet.Title;
                video.description = response.Items[0].Snippet.Description;
                video.publishedDate = response.Items[0].Snippet.PublishedAt.Value;
            }
            else
            {
                //Video id not found error
                Console.WriteLine("Video id not find...");
            }
        }
    }
}
