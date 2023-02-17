namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zyz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "NumberOfDumpsters", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "NumberOfDumpsters");
        }
    }
}
