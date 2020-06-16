using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using EventRegistrationApplication.Models;  // Connect controller to the model

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

        /* ENTITY FRAMEWORK gets data from controller and 
         * maps(passes & save) the data to SQL Server database.
         * Also maps a model class to a database table.
         * It manages all actions on database. */

        [HttpPost]
        // Refer to Client model class and define a variable of Client class type
        public ActionResult Register(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Create an object from EntityFramework class
                    // in order to use the class connected to the Client table
                    Database1Entities db = new Database1Entities();

                    // Add the client object from form input to the Clients entity 
                    db.Clients.Add(client);

                    // Save changes(properties of the object) to the database
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
        public ActionResult Detail()    // Read
        {
            // Create an object from EntityFramework class
            Database1Entities db = new Database1Entities();

            /* Read data from the table and pass the data to controller.
             * x refers to a record (each row) in the Client table.
             * LINQ query below saves all the records into the variable cl (Client class type)
             * (Clients is a Client table entity in entity framework) */
            var cl = from x in db.Clients
                     select x;
            
            // Pass the cl to a View file
            return View(cl);
        }
        /* Parameters of the Edit() action come from the form input (from the View). 
           Form data is bound to Edit() action.*/
        public ActionResult Edit(string email, string address, string phone)
        {
            try
            {
                Database1Entities db = new Database1Entities();

                /* x refers to a record in the Client table.
                 * Search Client table records and find a (first) record of the table 
                 * where the Email of the record equals to the email of the user input,
                 * and save to the variable client. */
                var client = db.Clients.First(x => x.Email == email);

                // Update the field of Client table with new data coming from the form.
                client.Address = address;
                client.Phone = phone;

                // Map the changes to the table and update the database
                db.SaveChanges();

                return RedirectToAction("editResult");
            }
            catch
            {
                return RedirectToAction("Index3");
            }            
        }
        
        // Delete multiple records by non-primary key
        public ActionResult Delete(string name)
        {
            Database1Entities db = new Database1Entities();

            /* x refers to a record in the Client table.
             * Search Client table records and find a record 
             * where any record's FullName equals to the name of the user input from the View,
             * put them into a list and save to the variable client. */
            List<Client> cl = db.Clients.Where(x => x.FullName == name).ToList();

            /* Use a loop for multiple records.
             * i refers to each record of the cl list. */
            foreach (var i in cl)
            {
                // Remove all the records in the cl list
                db.Clients.Remove(i);
            }
            db.SaveChanges();

            return RedirectToAction("Detail");
        }
        
        // Delete based on primary key
        public ActionResult DelByKey(string email)
        {
            Database1Entities db = new Database1Entities();

            // Find a record, email, from the table and save to the variable cl
            Client cl = db.Clients.Find(email);

            // Remove the record
            db.Clients.Remove(cl);

            // Map the changes to the table and update the database
            db.SaveChanges();
            return RedirectToAction("Detail");
        }

        public ActionResult Index4()
        {
            return View();
        }
    }
}