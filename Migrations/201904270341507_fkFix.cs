namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkFix : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("Caf_OrderItemModel", "MenuItem_MenuID", "Caf_MenuItemModel");
            //DropIndex("Caf_OrderItemModel", new[] { "MenuItem_MenuID" });
            //RenameColumn(table: "Caf_OrderItemModel", name: "MenuItem_MenuID", newName: "MenuID");
            AlterColumn("Caf_OrderItemModel", "MenuID", c => c.Int(nullable: false));
            CreateIndex("Caf_OrderItemModel", "MenuID");
            AddForeignKey("Caf_OrderItemModel", "MenuID", "dbo.Caf_MenuItemModel", "MenuID", cascadeDelete: true);
            DropColumn("Caf_OrderItemModel", "ItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Caf_OrderItemModel", "ItemID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Caf_OrderItemModel", "MenuID", "dbo.Caf_MenuItemModel");
            DropIndex("dbo.Caf_OrderItemModel", new[] { "MenuID" });
            AlterColumn("dbo.Caf_OrderItemModel", "MenuID", c => c.Int());
            RenameColumn(table: "dbo.Caf_OrderItemModel", name: "MenuID", newName: "MenuItem_MenuID");
            CreateIndex("dbo.Caf_OrderItemModel", "MenuItem_MenuID");
            AddForeignKey("dbo.Caf_OrderItemModel", "MenuItem_MenuID", "dbo.Caf_MenuItemModel", "MenuID");
        }
    }
}
