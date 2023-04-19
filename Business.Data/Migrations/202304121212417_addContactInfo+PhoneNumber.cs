namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContactInfoPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "FirstName", c => c.String());
            AddColumn("dbo.Client", "LastName", c => c.String());
            AddColumn("dbo.Client", "PhoneNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "PhoneNumber");
            DropColumn("dbo.Client", "LastName");
            DropColumn("dbo.Client", "FirstName");
        }
    }
}
