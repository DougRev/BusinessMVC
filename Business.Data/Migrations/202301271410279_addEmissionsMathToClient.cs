namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmissionsMathToClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "ToClientDist", c => c.Single(nullable: false));
            AddColumn("dbo.Client", "FromClientDist", c => c.Single(nullable: false));
            AddColumn("dbo.Client", "ToHaulerDist", c => c.Single(nullable: false));
            AddColumn("dbo.Client", "FromHaulerDist", c => c.Single(nullable: false));
            AddColumn("dbo.Client", "HaulsPerDay", c => c.Int(nullable: false));
            AddColumn("dbo.Client", "PreSMTYearlyHauls", c => c.Int(nullable: false));
            DropColumn("dbo.Client", "ClientDist");
            DropColumn("dbo.Client", "HaulerDist");
            DropColumn("dbo.Client", "YearlySmashes");
            DropColumn("dbo.Client", "Num1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "Num1", c => c.Int(nullable: false));
            AddColumn("dbo.Client", "YearlySmashes", c => c.Int(nullable: false));
            AddColumn("dbo.Client", "HaulerDist", c => c.Single(nullable: false));
            AddColumn("dbo.Client", "ClientDist", c => c.Single(nullable: false));
            DropColumn("dbo.Client", "PreSMTYearlyHauls");
            DropColumn("dbo.Client", "HaulsPerDay");
            DropColumn("dbo.Client", "FromHaulerDist");
            DropColumn("dbo.Client", "ToHaulerDist");
            DropColumn("dbo.Client", "FromClientDist");
            DropColumn("dbo.Client", "ToClientDist");
        }
    }
}
