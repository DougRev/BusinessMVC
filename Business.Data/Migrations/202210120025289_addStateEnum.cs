namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStateEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Business", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Business", "State");
        }
    }
}
