namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFranchiseTotalProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Franchise", "TotalCO2Saved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "GallonsSaved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "CoalSaved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "VehiclesSaved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "SmartPhonesSaved", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Franchise", "SmartPhonesSaved");
            DropColumn("dbo.Franchise", "VehiclesSaved");
            DropColumn("dbo.Franchise", "CoalSaved");
            DropColumn("dbo.Franchise", "GallonsSaved");
            DropColumn("dbo.Franchise", "TotalCO2Saved");
        }
    }
}
