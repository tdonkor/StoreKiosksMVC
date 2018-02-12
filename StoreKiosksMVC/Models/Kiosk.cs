using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace StoreKiosksMVC.Models
{
    public class Kiosk
    {
        public int Id { get; set; }
        public int KioskId { get; set; }
        public int StoreId { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string Customer { get; set; }
        public string SerialNumber { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string KioskName { get; set; }
        public string IpAddress { get; set; }
        public string EFTSerialNumber { get; set; }
        public string TPVNumber { get; set; }
    }
}