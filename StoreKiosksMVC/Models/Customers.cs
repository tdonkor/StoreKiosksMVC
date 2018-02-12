using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StoreKiosksMVC.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string Customer { get; set; }
    }
}