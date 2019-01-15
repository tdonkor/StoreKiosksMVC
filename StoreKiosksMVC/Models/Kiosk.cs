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
        [StringLength(100, MinimumLength = 1)]
        public string SerialNumber { get; set; }
        public bool DoubleSided { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string KioskName { get; set; }
        [StringLength(100)]
        public string IpAddress { get; set; }
        [StringLength(100)]
        public string EFTSerialTID1 { get; set; }
        [StringLength(100)]
        public string EFTSerialTID2 { get; set; }
        [StringLength(100)]
        public string EFTSerialNumber1 { get; set; }
        [StringLength(100)]
        public string EFTSerialNumber2 { get; set; }
        [StringLength(100)]
        public string TPVNumber { get; set; }
        [StringLength(100)]
        public string EFTMacAddress1 { get; set; }
        [StringLength(100)]
        public string EFTMacAddress2 { get; set; }
        [StringLength(100)]
        public string TeamViewerId { get; set; }
    }
}