namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _46update : DbMigration
    {
        public override void Up()
        {
            AddColumn("Caf_CartModel", "Quantity", c => c.Int(nullable: false));
            AddColumn("Caf_CartModel", "SpecialInstructions", c => c.String(unicode: false));
            AddColumn("Caf_CartModel", "DateCreated", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("Caf_CartModel", "MenuItem_MenuID", c => c.Int());
            AddColumn("Caf_OrderItemModel", "MenuItem_MenuID", c => c.Int());
            AddColumn("Caf_MenuItemModel", "Category", c => c.String(unicode: false));
            AlterColumn("Caf_CartModel", "CartID", c => c.String(unicode: false));
            CreateIndex("Caf_CartModel", "MenuItem_MenuID");
            CreateIndex("Caf_OrderItemModel", "MenuItem_MenuID");
            AddForeignKey("Caf_CartModel", "MenuItem_MenuID", "Caf_MenuItemModel", "MenuID");
            AddForeignKey("Caf_OrderItemModel", "MenuItem_MenuID", "Caf_MenuItemModel", "MenuID");
        }
        
        public override void Down()
        {
            DropForeignKey("Caf_OrderItemModel", "MenuItem_MenuID", "Caf_MenuItemModel");
            DropForeignKey("Caf_CartModel", "MenuItem_MenuID", "Caf_MenuItemModel");
            DropIndex("Caf_OrderItemModel", new[] { "MenuItem_MenuID" });
            DropIndex("Caf_CartModel", new[] { "MenuItem_MenuID" });
            AlterColumn("Caf_CartModel", "CartID", c => c.Int(nullable: false));
            DropColumn("Caf_MenuItemModel", "Category");
            DropColumn("Caf_OrderItemModel", "MenuItem_MenuID");
            DropColumn("Caf_CartModel", "MenuItem_MenuID");
            DropColumn("Caf_CartModel", "DateCreated");
            DropColumn("Caf_CartModel", "SpecialInstructions");
            DropColumn("Caf_CartModel", "Quantity");
        }
    }
}
