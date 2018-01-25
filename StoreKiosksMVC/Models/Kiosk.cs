using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StoreKiosksMVC.Models
{
    public class Kiosk
    {
        public int Id { get; set; }
        public int KioskId { get; set; }
        public int StoreId { get; set; }
        public string SerialNumber { get; set; }
        public string KioskName { get; set; }
        public string IpAddress { get; set; }
        public string EFTSerialNumber { get; set; }
        public string TPVNumber { get; set; }
    }
}