namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingQuoteView : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "AddToDb", c => c.Boolean(nullable: false));
            DropColumn("dbo.Client", "XferStation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "XferStation", c => c.Boolean(nullable: false));
            DropColumn("dbo.Client", "AddToDb");
        }
    }
}
