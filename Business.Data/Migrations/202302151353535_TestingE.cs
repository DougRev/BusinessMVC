namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Franchise", "EmissionsSavedWithSmash", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Franchise", "EmissionsSavedWithSmash");
        }
    }
}
