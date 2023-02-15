namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationDBFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "EmissionsSavedWithSmash", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "EmissionsSavedWithSmash");
        }
    }
}
