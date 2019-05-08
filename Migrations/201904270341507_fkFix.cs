namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Caf_OrderItemModel", "MenuItem_MenuID", "Caf_MenuItemModel");
            DropIndex("Caf_OrderItemModel", new[] { "MenuItem_MenuID" });
            RenameColumn(table: "Caf_OrderItemModel", name: "MenuItem_MenuID", newName: "MenuID");
            AlterColumn("Caf_OrderItemModel", "MenuID", c => c.Int(nullable: false));
            CreateIndex("Caf_OrderItemModel", "MenuID");
            AddForeignKey("Caf_OrderItemModel", "MenuID", "Caf_MenuItemModel", "MenuID", cascadeDelete: true);
            DropColumn("Caf_OrderItemModel", "ItemID");
        }
        
        public override void Down()
        {
            AddColumn("Caf_OrderItemModel", "ItemID", c => c.Int(nullable: false));
            DropForeignKey("Caf_OrderItemModel", "MenuID", "Caf_MenuItemModel");
            DropIndex("Caf_OrderItemModel", new[] { "MenuID" });
            AlterColumn("Caf_OrderItemModel", "MenuID", c => c.Int());
            RenameColumn(table: "Caf_OrderItemModel", name: "MenuID", newName: "MenuItem_MenuID");
            CreateIndex("Caf_OrderItemModel", "MenuItem_MenuID");
            AddForeignKey("Caf_OrderItemModel", "MenuItem_MenuID", "Caf_MenuItemModel", "MenuID");
        }
    }
}
