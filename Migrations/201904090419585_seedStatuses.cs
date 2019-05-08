namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedStatuses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "FoodStatusModels",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            AddColumn("Caf_InvoiceModel", "StatusId", c => c.Int(nullable: false));
            CreateIndex("Caf_InvoiceModel", "StatusId");
            AddForeignKey("Caf_InvoiceModel", "StatusId", "FoodStatusModels", "StatusId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Caf_InvoiceModel", "StatusId", "FoodStatusModels");
            DropIndex("Caf_InvoiceModel", new[] { "StatusId" });
            DropColumn("Caf_InvoiceModel", "StatusId");
            DropTable("FoodStatusModels");
        }
    }
}
