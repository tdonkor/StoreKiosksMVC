using StoreKiosksMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}