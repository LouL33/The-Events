using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheEvents.Models;
using System.Data.Entity;
using TheEvents.CacheServices;

namespace TheEvents.Controllers
{
    public class HomeController : Controller
    {
        private String eventCacheKey = CacheKeys.Events();

        public ActionResult Index()
        {
            var schedule = HttpRuntime.Cache["events"] as IEnumerable<Events>;
            if (schedule == null)
            {
                var eventsStatus = new ApplicationDbContext().Events.Include(i => i.Genres).Include(i => i.Venue).ToList();
                HttpRuntime.Cache.Add(
                    "eventsStatus",
                    eventsStatus,
                    null,
                    DateTime.Now.AddDays(27),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.High,
                    null
                    );

                schedule = HttpRuntime.Cache["events"] as IEnumerable<Events>;
            }

            return View(schedule);
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