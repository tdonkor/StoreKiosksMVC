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
    public class KiosksController : Controller
    {
        private StoreKiosksDB db = new StoreKiosksDB();


        // GET: Kiosks
        public ActionResult Index( int? storeId, string cust)
        {
            if (storeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           

            var kiosks = from kiosk in db.Kiosks.ToList()
                         where kiosk.StoreId == storeId
                         select kiosk;
            


            if (kiosks == null)
            {
                return HttpNotFound();
            }

            //use the storeId value in other controllers
            TempData["StoreId"] = storeId;
            TempData["Customer"] = cust;

            return View(kiosks);

           // return View(db.Kiosks.ToList());
        }

        // GET: Kiosks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiosk kiosk = db.Kiosks.Find(id);
            if (kiosk == null)
            {
                return HttpNotFound();
            }
            return View(kiosk);
        }

        // GET: Kiosks/Create
        public ActionResult Create()
        {
            int storeId = Convert.ToInt32(TempData["StoreId"]);
            ViewData["StoreId"] = storeId;
         

            return View();
        }

        // POST: Kiosks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KioskId,StoreId,Customer,SerialNumber,KioskName,IpAddress,EFTSerialNumber,TPVNumber")] Kiosk kiosk)
        {
            //kiosk.Id = kiosk.KioskId;

            // Don't create if Kiosk name is blank
            //if ( (string.IsNullOrEmpty(kiosk.KioskName)))
            //{
            //    return RedirectToAction("Index", "Stores");
            //}
            ViewData["Customer"] = kiosk.Customer;
            if (ModelState.IsValid)
            {
                db.Kiosks.Add(kiosk);
                db.SaveChanges();
                return RedirectToAction("Index", "Kiosks", new { storeId = kiosk.StoreId });
            }

            return View(kiosk);
        }

        // GET: Kiosks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiosk kiosk = db.Kiosks.Find(id);

            ViewData["Customer"] = kiosk.Customer;

            if (kiosk == null)
            {
                return HttpNotFound();
            }
            //ViewBag.StoreId = kiosk.StoreId;
            ViewData["StoreId"] = kiosk.StoreId;
            return View(kiosk);
        }

        // POST: Kiosks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KioskId,StoreId,Customer,SerialNumber,KioskName,IpAddress,EFTSerialNumber,TPVNumber")] Kiosk kiosk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kiosk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Kiosks", new { storeId = kiosk.StoreId });
            }
            return View(kiosk);
        }

        // GET: Kiosks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiosk kiosk = db.Kiosks.Find(id);
            if (kiosk == null)
            {
                return HttpNotFound();
            }
            ViewData["StoreId"] = kiosk.StoreId;
            ViewData["Customer"] = kiosk.Customer;
            return View(kiosk);
        }

        // POST: Kiosks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kiosk kiosk = db.Kiosks.Find(id);
            db.Kiosks.Remove(kiosk);
            db.SaveChanges();
            return RedirectToAction("Index", "Kiosks", new { storeId = kiosk.StoreId });
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
