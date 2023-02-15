namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingF1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Franchise", "EmissionsSavedWithSmash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Franchise", "EmissionsSavedWithSmash", c => c.Double(nullable: false));
        }
    }
}
