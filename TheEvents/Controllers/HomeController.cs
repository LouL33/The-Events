using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheEvents.Models;

namespace TheEvents.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
            var timeToDisplay = HttpRuntime.Cache["timeStamp"];

            if (timeToDisplay == null)
            {
                HttpRuntime.Cache.Add("timeStamp",
                    DateTime.Now,
                    null,
                    DateTime.Now.AddDays(7),
                    new TimeSpan(8, 0, 0),
                    System.Web.Caching.CacheItemPriority.Normal,
                    null
                    );
                 timeToDisplay = HttpRuntime.Cache["timeStamp"];
            }
            else
            {

            }

            ViewBag.FromCache = timeToDisplay;
            */

            var events = new ApplicationDbContext().Events.OrderBy(o => o.StartTime).ToList();

            return View(events);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}