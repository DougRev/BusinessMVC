namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Business", "Num1", c => c.Int(nullable: false));
            AddColumn("dbo.Business", "Num2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Business", "Num2");
            DropColumn("dbo.Business", "Num1");
        }
    }
}
