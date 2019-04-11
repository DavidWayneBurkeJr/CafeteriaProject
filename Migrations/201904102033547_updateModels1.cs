namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Caf_FoodCategories",
            //    c => new
            //        {
            //            CategoryId = c.Int(nullable: false, identity: true),
            //            Category = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.CategoryId);

            //AddColumn("Caf_MenuItemModel", "CategoryId", c => c.Int(nullable: false));
            //CreateIndex("Caf_MenuItemModel", "CategoryId");
            //DropColumn("Caf_MenuItemModel", "Category");
            AddForeignKey("Caf_MenuItemModel", "CategoryId", "Caf_FoodCategories", "CategoryId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Caf_MenuItemModel", "Category", c => c.String(nullable: false, unicode: false));
            DropForeignKey("dbo.Caf_MenuItemModel", "CategoryId", "dbo.Caf_FoodCategories");
            DropIndex("dbo.Caf_MenuItemModel", new[] { "CategoryId" });
            DropColumn("dbo.Caf_MenuItemModel", "CategoryId");
            DropTable("dbo.Caf_FoodCategories");
        }
    }
}
