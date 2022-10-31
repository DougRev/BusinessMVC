namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIntToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Business", "ClientDist", c => c.Single(nullable: false));
            AlterColumn("dbo.Business", "HaulerDist", c => c.Single(nullable: false));
            AlterColumn("dbo.Business", "LandfillDist", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Business", "LandfillDist", c => c.Int(nullable: false));
            AlterColumn("dbo.Business", "HaulerDist", c => c.Int(nullable: false));
            AlterColumn("dbo.Business", "ClientDist", c => c.Int(nullable: false));
        }
    }
}
