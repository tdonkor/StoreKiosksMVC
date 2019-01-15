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
        [StringLength(100, MinimumLength = 1)]
        public string Customer { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string StoreName { get; set; }
        [StringLength(50)]
        public string StoreNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InstallationDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GoLiveDate { get; set; }
        [StringLength(100)]
        public string KioskNUCIP { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        public string Address1 { get; set; }
        [StringLength(100)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string County { get; set; }
        [StringLength(50)]
        public string Postcode { get; set; }
        public List<Kiosk> Kiosks { get; set; }
    }
}