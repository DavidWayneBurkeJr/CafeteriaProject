namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _46update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Caf_CartModel", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Caf_CartModel", "SpecialInstructions", c => c.String(unicode: false));
            AddColumn("dbo.Caf_CartModel", "DateCreated", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Caf_CartModel", "MenuItem_MenuID", c => c.Int());
            AddColumn("dbo.Caf_OrderItemModel", "MenuItem_MenuID", c => c.Int());
            AddColumn("dbo.Caf_MenuItemModel", "Category", c => c.String(unicode: false));
            AlterColumn("dbo.Caf_CartModel", "CartID", c => c.String(unicode: false));
            CreateIndex("dbo.Caf_CartModel", "MenuItem_MenuID");
            CreateIndex("dbo.Caf_OrderItemModel", "MenuItem_MenuID");
            AddForeignKey("dbo.Caf_CartModel", "MenuItem_MenuID", "dbo.Caf_MenuItemModel", "MenuID");
            AddForeignKey("dbo.Caf_OrderItemModel", "MenuItem_MenuID", "dbo.Caf_MenuItemModel", "MenuID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Caf_OrderItemModel", "MenuItem_MenuID", "dbo.Caf_MenuItemModel");
            DropForeignKey("dbo.Caf_CartModel", "MenuItem_MenuID", "dbo.Caf_MenuItemModel");
            DropIndex("dbo.Caf_OrderItemModel", new[] { "MenuItem_MenuID" });
            DropIndex("dbo.Caf_CartModel", new[] { "MenuItem_MenuID" });
            AlterColumn("dbo.Caf_CartModel", "CartID", c => c.Int(nullable: false));
            DropColumn("dbo.Caf_MenuItemModel", "Category");
            DropColumn("dbo.Caf_OrderItemModel", "MenuItem_MenuID");
            DropColumn("dbo.Caf_CartModel", "MenuItem_MenuID");
            DropColumn("dbo.Caf_CartModel", "DateCreated");
            DropColumn("dbo.Caf_CartModel", "SpecialInstructions");
            DropColumn("dbo.Caf_CartModel", "Quantity");
        }
    }
}
