namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Compactibility", c => c.Int(nullable: false));
            DropColumn("dbo.Client", "PreSMTYearlyHauls");
            DropColumn("dbo.Client", "Num2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "Num2", c => c.Int(nullable: false));
            AddColumn("dbo.Client", "PreSMTYearlyHauls", c => c.Int(nullable: false));
            DropColumn("dbo.Client", "Compactibility");
        }
    }
}
