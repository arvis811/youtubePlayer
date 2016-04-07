using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace youtubePlayer.Models
{
    public class YouTubeVideo
    {
        public YouTubeVideo videoId;
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime publishedDate { get; set; }

        public YouTubeVideo(string id)
        {
            this.id = id;
            YouTubeApi.GetVideoInfo(this);
        }
    }
}
