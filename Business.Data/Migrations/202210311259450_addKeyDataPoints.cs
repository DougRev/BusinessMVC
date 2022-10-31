namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKeyDataPoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Business", "XferStation", c => c.Boolean(nullable: false));
            AddColumn("dbo.Business", "ClientDist", c => c.Int(nullable: false));
            AddColumn("dbo.Business", "HaulerDist", c => c.Int(nullable: false));
            AddColumn("dbo.Business", "LandfillDist", c => c.Int(nullable: false));
            AddColumn("dbo.Business", "YearlySmashes", c => c.Int(nullable: false));
            DropColumn("dbo.Business", "BusinessIdNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Business", "BusinessIdNumber", c => c.Int());
            DropColumn("dbo.Business", "YearlySmashes");
            DropColumn("dbo.Business", "LandfillDist");
            DropColumn("dbo.Business", "HaulerDist");
            DropColumn("dbo.Business", "ClientDist");
            DropColumn("dbo.Business", "XferStation");
        }
    }
}
