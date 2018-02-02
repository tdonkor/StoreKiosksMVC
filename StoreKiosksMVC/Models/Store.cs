using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StoreKiosksMVC.Models
{
    public class Store
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string StoreName { get; set; }
        public string StoreNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GoLiveDate { get; set; }
        public string KioskNUCIP { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public List<Kiosk> Kiosks { get; set; }
    }
}