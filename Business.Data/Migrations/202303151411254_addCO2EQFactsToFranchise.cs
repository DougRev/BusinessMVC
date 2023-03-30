namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCO2EQFactsToFranchise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Franchise", "TotalCO2Saved", c => c.Single(nullable: false));
            AddColumn("dbo.Franchise", "GallonsSaved", c => c.Int(nullable: false));
            AddColumn("dbo.Franchise", "CoalSaved", c => c.Int(nullable: false));
            AddColumn("dbo.Franchise", "VehiclesSaved", c => c.Int(nullable: false));
            AddColumn("dbo.Franchise", "SmartPhonesSaved", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {

        }
    }
}
