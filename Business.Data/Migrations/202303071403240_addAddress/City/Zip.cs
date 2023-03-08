namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressCityZip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "City", c => c.String());
            AddColumn("dbo.Client", "Address", c => c.String());
            AddColumn("dbo.Client", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "ZipCode");
            DropColumn("dbo.Client", "Address");
            DropColumn("dbo.Client", "City");
        }
    }
}
