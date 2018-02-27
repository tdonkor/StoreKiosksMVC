using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreKiosksMVC;
using StoreKiosksMVC.Controllers;

namespace StoreKiosksMVC.Tests.Controllers
{
    class KioskControllerTest
    {
        //test data
        int? num = 1;
        string name = "KFC";

        [TestMethod]
        public void Index()
        {
            // Arrange
            KiosksController controller = new KiosksController();

            // Act
            ViewResult result = controller.Index(num, name) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            KiosksController controller = new KiosksController();

            //// Act
            //ViewResult result = controller.About() as ViewResult;

            //// Assert
            //Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            //// Arrange
            //KiosksController controller = new KiosksController();

            //// Act
            //ViewResult result = controller.Contact() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }
    }
}
