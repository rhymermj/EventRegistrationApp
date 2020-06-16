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
        public ActionResult Register(Register Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Database1Entities db = new Database1Entities();
                    db.Registers.Add(Model);
                    db.SaveChanges();

                    return RedirectToAction("Detail");
                }
            }
            catch
            {
                return RedirectToAction("RegResult");
            }
            return View(Model);
        }
        public ActionResult RegResult()
        {
            return View();
        }
        public ActionResult DelResult()
        {
            return View();
        }

        public ActionResult Detail()
        {
            // Create an object in order to use Database1Entities class connect to the tables
            Database1Entities db = new Database1Entities();

            var evt = from x in db.Registers select x;

            return View(evt);
        }
        /*
        public ActionResult Delete(string name, string email)
        {
            try
            {
                Database1Entities db = new Database1Entities();

                List<Register> reg = db.Registers.Where(x => x.EventName == name && x.Email == email).ToList();

                foreach (var i in reg)
                {
                    db.Registers.Remove(i);
                }
                db.SaveChanges();

                return RedirectToAction("Detail");
            }
            catch
            {
                return RedirectToAction("DelResult");
            }
        }*/
        public ActionResult Delete(string name, string email)
        {
            try
            {
                Database1Entities db = new Database1Entities();

                /* x refers to a record in the Register table.
                 * Search Register table records and find a (first) record of the table where
                 * the EventName & Email of the record equals to the name & email of the user input,
                 * and save to the variable client. */
                Register reg = db.Registers.First(x => x.EventName == name && x.Email == email);
                
                // Remove the reg record from the table.
                db.Registers.Remove(reg);

                // Map the changes to the table and update the database.
                db.SaveChanges();

                return RedirectToAction("Detail");
            }
            catch
            {
                return RedirectToAction("DelResult");
            }


        }


    }
}