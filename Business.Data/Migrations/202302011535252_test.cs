namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Client", "FranchiseId", "dbo.Franchise");
            DropForeignKey("dbo.Client", "FranchiseeId", "dbo.FranchiseOwner");
            DropIndex("dbo.Client", new[] { "FranchiseeId" });
            DropIndex("dbo.Client", new[] { "FranchiseId" });
            RenameColumn(table: "dbo.Client", name: "FranchiseId", newName: "Franchise_FranchiseId");
            RenameColumn(table: "dbo.Client", name: "FranchiseeId", newName: "FranchiseOwner_FranchiseeId");
            AlterColumn("dbo.Client", "FranchiseOwner_FranchiseeId", c => c.Int());
            AlterColumn("dbo.Client", "Franchise_FranchiseId", c => c.Int());
            CreateIndex("dbo.Client", "FranchiseOwner_FranchiseeId");
            CreateIndex("dbo.Client", "Franchise_FranchiseId");
            AddForeignKey("dbo.Client", "Franchise_FranchiseId", "dbo.Franchise", "FranchiseId");
            AddForeignKey("dbo.Client", "FranchiseOwner_FranchiseeId", "dbo.FranchiseOwner", "FranchiseeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "FranchiseOwner_FranchiseeId", "dbo.FranchiseOwner");
            DropForeignKey("dbo.Client", "Franchise_FranchiseId", "dbo.Franchise");
            DropIndex("dbo.Client", new[] { "Franchise_FranchiseId" });
            DropIndex("dbo.Client", new[] { "FranchiseOwner_FranchiseeId" });
            AlterColumn("dbo.Client", "Franchise_FranchiseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Client", "FranchiseOwner_FranchiseeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Client", name: "FranchiseOwner_FranchiseeId", newName: "FranchiseeId");
            RenameColumn(table: "dbo.Client", name: "Franchise_FranchiseId", newName: "FranchiseId");
            CreateIndex("dbo.Client", "FranchiseId");
            CreateIndex("dbo.Client", "FranchiseeId");
            AddForeignKey("dbo.Client", "FranchiseeId", "dbo.FranchiseOwner", "FranchiseeId", cascadeDelete: true);
            AddForeignKey("dbo.Client", "FranchiseId", "dbo.Franchise", "FranchiseId", cascadeDelete: true);
        }
    }
}
