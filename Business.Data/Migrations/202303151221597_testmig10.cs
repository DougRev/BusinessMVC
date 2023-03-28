namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testmig10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Franchise", "TotalCO2Saved");
            DropColumn("dbo.Franchise", "GallonsSaved");
            DropColumn("dbo.Franchise", "CoalSaved");
            DropColumn("dbo.Franchise", "VehiclesSaved");
            DropColumn("dbo.Franchise", "SmartPhonesSaved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Franchise", "SmartPhonesSaved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "VehiclesSaved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "CoalSaved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "GallonsSaved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "TotalCO2Saved", c => c.Single(nullable: false));
        }
    }
}
