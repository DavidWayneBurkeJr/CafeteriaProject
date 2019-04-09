namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedStatuses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodStatusModels",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("dbo.Caf_InvoiceModel", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Caf_InvoiceModel", "StatusId");
            AddForeignKey("dbo.Caf_InvoiceModel", "StatusId", "dbo.FoodStatusModels", "StatusId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Caf_InvoiceModel", "StatusId", "dbo.FoodStatusModels");
            DropIndex("dbo.Caf_InvoiceModel", new[] { "StatusId" });
            DropColumn("dbo.Caf_InvoiceModel", "StatusId");
            DropTable("dbo.FoodStatusModels");
        }
    }
}
