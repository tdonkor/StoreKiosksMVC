namespace StoreKiosksMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kiosks", "KioskName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Stores", "StoreName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "StoreName", c => c.String());
            AlterColumn("dbo.Kiosks", "KioskName", c => c.String());
        }
    }
}
