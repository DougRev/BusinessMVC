namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFacilityID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "FacilityID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "FacilityID");
        }
    }
}
