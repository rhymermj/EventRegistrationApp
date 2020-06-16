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

            // Search by exact match 
            List<Event> evt = db.Events.Where(x => x.EventName == name || x.Date == date).ToList();
            return View(evt);
        }       
        public ActionResult Detail()
        {
            // Create an object in order to use Database1Entities class connected to the Event table.
            Database1Entities db = new Database1Entities();

            var evt = from x in db.Events
                      select x;

            return View(evt);
        }
    }
}