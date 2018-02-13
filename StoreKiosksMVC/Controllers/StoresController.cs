using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreKiosksMVC.Models;

namespace StoreKiosksMVC.Controllers
{
    public class StoresController : Controller
    {
        private StoreKiosksDB db = new StoreKiosksDB();


        // GET: Stores
        public ActionResult Index(string cust)
        {
         
            TempData["Customer"] = cust;

            var model =
                 from stores in db.Stores
                     //  orderby stores.StoreName ascending
                     // where (Id == null || stores.Customer.StartsWith(Id))
                 where stores.Customer == cust
                 select stores;

            
            return View(model);

            //return View(db.Stores.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
         
            ViewData["StoreName"] = store.StoreName.ToUpper();
            ViewData["Customer"] = store.Customer;

            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create(string cust)
        {

            ViewData["Customer"] = cust;
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StoreName,Customer,StoreNumber,GoLiveDate,KioskNUCIP,PhoneNumber,Address1,Address2,City,County,Postcode")] Store store)
        {
            // trim any spaces from the storeName
            store.StoreName = TrimString(store.StoreName);
            TempData["Customer"] = store.Customer;

            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction($"Index", new {cust = store.Customer});
            }

            return View(store);
        }
        
        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);

            ViewData["Customer"] = store.Customer;
            ViewData["StoreName"] = store.StoreName;
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StoreName,Customer,StoreNumber,GoLiveDate,KioskNUCIP,PhoneNumber,Address1,Address2,City,County,Postcode")] Store store)
        {
            if (ModelState.IsValid)
            {
                // trim any spaces from the storeName
                store.StoreName = TrimString(store.StoreName);
                ViewData["Customers"] = store.Customer;

                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction($"Index", new { cust = store.Customer });
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            ViewData["StoreName"] = store.StoreName;
            ViewData["Customer"] = store.Customer;

            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return RedirectToAction($"Index", new {cust = store.Customer});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
