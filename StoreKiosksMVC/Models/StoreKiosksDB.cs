using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StoreKiosksMVC.Models
{
    public class StoreKiosksDB : DbContext
    {
        public StoreKiosksDB() : base("name=StoreKiosksDB")
        {

        }

        public static string cust { get; internal set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Kiosk> Kiosks { get; set; }
        public DbSet<Customers> Customers { get; set; }

    }
}