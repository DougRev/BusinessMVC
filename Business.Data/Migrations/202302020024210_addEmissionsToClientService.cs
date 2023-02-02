namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmissionsToClientService : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Client", "TestTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "TestTotal", c => c.Double(nullable: false));
        }
    }
}
