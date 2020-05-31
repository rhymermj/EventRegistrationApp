using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventRegistrationApplication.Models;

namespace EventRegistrationApplication.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(string name, string date)
        {
            Database1Entities db = new Database1Entities();

            // Search by exact match - WORKS
            //List<Event> e = db.Events.Where(x => x.EventName == name || x.Date == date).ToList();
            //return View(e);

            // Also works for exact match
            var s = from x in db.Events where x.EventName == name || x.Date == date select x;
            return View(s);
        }

        public ActionResult Detail()
        {
            // Create an object in order to use Database1Entities class connect to the tables
            Database1Entities db = new Database1Entities();

            var evt = from x in db.Events
                      select x;

            return View(evt);
        }
    }
}