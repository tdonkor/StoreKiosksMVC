using StoreKiosksMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace StoreKiosksMVC.Controllers
{
    public class HomeController : Controller
    {
        private StoreKiosksDB db = new StoreKiosksDB();

        public ActionResult Index()
        {
            var model =
                 from cust in db.Customers
                 orderby cust.Customer
                 select cust;

            return View(model);
        }
        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Customer")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction($"Index", new { cust = customers.Customer });
            }

            return View(customers);
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

        

        public ActionResult Delete(int? id)
        {
            //check store list for the customer is empty
            //before deleting

            // get customer name 
            Customers custName = (from cust in db.Customers
                                  where cust.Id == id
                                  select cust).First();

            //get store list for customer before deletion
            List<Store> strs = new List<Store>();
            strs = (from store in db.Stores
                    where store.Customer == custName.Customer.ToString()
                    select store).ToList();

            // if store list not empty redirect to different view 
            if (strs.Count != 0)
            {
                return RedirectToAction($"ListNotEmpty");

            }

            Customers customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);

        }
        // POST: customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);

            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }


        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Customer")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction($"Index");
            }
            return View(customers);
        }

        public ActionResult ListNotEmpty()
        {

            return View();
        }

        /// <summary>
        /// Trim the string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        string TrimString(string str)
        {
            return str.Trim();
        }
    }
}