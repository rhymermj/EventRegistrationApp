using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using EventRegistrationApplication.Models;

namespace EventRegistrationApplication.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client

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
        [HttpPost]
        public ActionResult Register(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Database1Entities db = new Database1Entities();
                    db.Clients.Add(client);
                    db.SaveChanges();

                    return RedirectToAction("RegResult");
                }
            }
            catch
            {
                return RedirectToAction("RegError");
            }
            
            return View(client);
        }
        public ActionResult RegResult()
        {
            return View();
        }
        public ActionResult RegError()
        {
            return View();
        }
        public ActionResult EditResult()
        {
            return View();
        }
        public ActionResult Detail()
        {
            Database1Entities db = new Database1Entities();

            var cl = from x in db.Clients
                     select x;

            return View(cl);
        }
        public ActionResult Edit(string email, string address, string phone)
        {
            try
            {
                Database1Entities db = new Database1Entities();

                var client = db.Clients.First(x => x.Email == email);

                client.Address = address;
                client.Phone = phone;
                db.SaveChanges();

                return RedirectToAction("editResult");
            }
            catch
            {
                return RedirectToAction("Index3");
            }            
        }

        public string Delete(string name)
        {
            Database1Entities db = new Database1Entities();

            List<Client> c = db.Clients.Where(x => x.FullName == name).ToList();

            foreach (var i in c)
            {
                db.Clients.Remove(i);
            }
            db.SaveChanges();

            return "deleted";

        }
    }
}