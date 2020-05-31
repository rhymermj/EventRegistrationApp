using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventRegistrationApplication.Models;

namespace EventRegistrationApplication.Controllers
{
    public class EventController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Event list
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult register(Register reg)
        {
            if (ModelState.IsValid)
            {
                Database1Entities db = new Database1Entities();
                db.Registers.Add(reg);
                db.SaveChanges();

                return RedirectToAction("regResult");
            }
            return View(reg);
        }
        public ActionResult RegResult()
        {
            return View();
        }
        public ActionResult Detail()
        {
            // Create an object in order to use Database1Entities class connect to the tables
            Database1Entities db = new Database1Entities();

            var evt = from x in db.Registers
                      select x;

            return View(evt);
        }
        public ActionResult delete(string name, string email)
        {
            Database1Entities db = new Database1Entities();

            List<Register> reg = db.Registers.Where(x => x.EventName == name && x.Email == email).ToList();

            foreach (var i in reg)
            {
                db.Registers.Remove(i);
            }
            db.SaveChanges();

            return RedirectToAction("delResult");
        }
        public ActionResult DelResult()
        {
            return View();
        }

        /*
        public string delete(string email, string name)
        {
            Database1Entities db = new Database1Entities();
            
            Register reg = db.Registers.First(x => x.Email == email && x.EventName == name);
            db.Registers.Remove(reg);
            db.SaveChanges();
            return "Delete successful";
        }*/

    }
}