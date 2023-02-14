namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientsToFranchise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "FranchiseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "FranchiseName");
        }
    }
}
