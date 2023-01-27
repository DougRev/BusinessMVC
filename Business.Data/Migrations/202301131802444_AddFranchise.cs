namespace BusinessData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFranchise : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Business", newName: "Client");
            RenameTable(name: "dbo.Franchisee", newName: "FranchiseOwner");
            CreateTable(
                "dbo.Franchise",
                c => new
                    {
                        FranchiseId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FranchiseName = c.String(),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FranchiseId);
            
            AddColumn("dbo.Client", "Franchise_FranchiseId", c => c.Int());
            CreateIndex("dbo.Client", "Franchise_FranchiseId");
            AddForeignKey("dbo.Client", "Franchise_FranchiseId", "dbo.Franchise", "FranchiseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "Franchise_FranchiseId", "dbo.Franchise");
            DropIndex("dbo.Client", new[] { "Franchise_FranchiseId" });
            DropColumn("dbo.Client", "Franchise_FranchiseId");
            DropTable("dbo.Franchise");
            RenameTable(name: "dbo.FranchiseOwner", newName: "Franchisee");
            RenameTable(name: "dbo.Client", newName: "Business");
        }
    }
}
