namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTotalCO2Franchise : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Franchise", "GallonsSaved");
            DropColumn("dbo.Franchise", "CoalSaved");
            DropColumn("dbo.Franchise", "VehiclesSaved");
            DropColumn("dbo.Franchise", "SmartPhonesSaved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Franchise", "TotalCO2Saved", c => c.Int(nullable: false));
            AddColumn("dbo.Franchise", "SmartPhonesSaved", c => c.Int(nullable: false));
            AddColumn("dbo.Franchise", "VehiclesSaved", c => c.Int(nullable: false));
            AddColumn("dbo.Franchise", "CoalSaved", c => c.Int(nullable: false));
            AddColumn("dbo.Franchise", "GallonsSaved", c => c.Int(nullable: false));
        }
    }
}
