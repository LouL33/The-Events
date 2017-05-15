using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheEvents.CacheServices;
using TheEvents.Models;

namespace TheEvents.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {

        private String eventCacheKey = CacheKeys.Events();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Genres).Include(e => e.Venue);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title");
            ViewBag.VenuesId = new SelectList(db.Venues, "Id", "Title");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,StartTime,EndTime,VenuesId,GenreId")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                HttpRuntime.Cache.Remove(eventCacheKey);
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
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", events.GenreId);
            ViewBag.VenuesId = new SelectList(db.Venues, "Id", "Title", events.VenuesId);
            return View(events);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", events.GenreId);
            ViewBag.VenuesId = new SelectList(db.Venues, "Id", "Title", events.VenuesId);
            return View(events);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,StartTime,EndTime,VenuesId,GenreId")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Title", events.GenreId);
            ViewBag.VenuesId = new SelectList(db.Venues, "Id", "Title", events.VenuesId);
            return View(events);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Events events = db.Events.Find(id);
            db.Events.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
