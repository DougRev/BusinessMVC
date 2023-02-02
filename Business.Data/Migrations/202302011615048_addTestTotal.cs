namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTestTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "TestTotal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "TestTotal");
        }
    }
}
