using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using youtubePlayer.Models;

namespace youtubePlayer.Controllers
{
    public class HomeController : Controller
    {
        public string name;
        public int age;
        public int Remaining;
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult VideoInfo()
        {
            return View();
        }

        public ActionResult GetVideoInfo(string videoId)
        {
            var Y = new YouTubeVideo(videoId);
            ViewBag.Output = "Video Title: " + Y.title;

            string embedlink = "<iframe width = \"560\" height = \"315\" src = \"https://www.youtube.com/embed/" + videoId + "\" frameborder = \"0\" allowfullscreen ></iframe >";
            ViewBag.Embed = embedlink;
            return View("VideoIdResult");
        }
        public string GetInfoWithDate()
        {
            return "Welcome " + DateTime.Now.ToString();
        }
        public ActionResult MyActionSubmit(string Name, int Age)
        {
            name = Name;
            age = Age;

            DataExecution D = new DataExecution();
            Remaining = D.CalculateRemainingAge(age);

            ViewBag.Result = "Hello " + Name + ", you are " + Age + " years old." + "You have to live " + Remaining + " years until you will turn 100 years old.";

            return View();
        }
    }
}