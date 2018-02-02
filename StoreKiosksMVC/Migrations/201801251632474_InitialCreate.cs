namespace StoreKiosksMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kiosks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KioskId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        SerialNumber = c.String(),
                        KioskName = c.String(),
                        IpAddress = c.String(),
                        EFTSerialNumber = c.String(),
                        TPVNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreName = c.String(),
                        StoreNumber = c.String(),
                        GoLiveDate = c.DateTime(nullable: false),
                        KioskNUCIP = c.String(),
                        PhoneNumber = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Postcode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kiosks", "StoreId", "dbo.Stores");
            DropIndex("dbo.Kiosks", new[] { "StoreId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Kiosks");
        }
    }
}
