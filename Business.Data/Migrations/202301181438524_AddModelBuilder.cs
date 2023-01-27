namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelBuilder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Client", "Franchise_FranchiseId", "dbo.Franchise");
            DropIndex("dbo.Client", new[] { "Franchise_FranchiseId" });
            RenameColumn(table: "dbo.Client", name: "Franchise_FranchiseId", newName: "FranchiseId");
            AlterColumn("dbo.Client", "FranchiseId", c => c.Int(nullable: true));
            CreateIndex("dbo.Client", "FranchiseId");
            AddForeignKey("dbo.Client", "FranchiseId", "dbo.Franchise", "FranchiseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "FranchiseId", "dbo.Franchise");
            DropIndex("dbo.Client", new[] { "FranchiseId" });
            AlterColumn("dbo.Client", "FranchiseId", c => c.Int());
            RenameColumn(table: "dbo.Client", name: "FranchiseId", newName: "Franchise_FranchiseId");
            CreateIndex("dbo.Client", "Franchise_FranchiseId");
            AddForeignKey("dbo.Client", "Franchise_FranchiseId", "dbo.Franchise", "FranchiseId");
        }
    }
}
