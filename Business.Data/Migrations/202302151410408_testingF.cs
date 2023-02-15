namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingF : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Client", "EmissionsSavedWithSmash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "EmissionsSavedWithSmash", c => c.Double(nullable: false));
        }
    }
}
