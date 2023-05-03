namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingdbmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Client", "FirstName");
            DropColumn("dbo.Client", "LastName");
            DropColumn("dbo.Client", "PhoneNumber");
            DropColumn("dbo.Client", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "Email", c => c.String());
            AddColumn("dbo.Client", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Client", "LastName", c => c.String());
            AddColumn("dbo.Client", "FirstName", c => c.String());
        }
    }
}
