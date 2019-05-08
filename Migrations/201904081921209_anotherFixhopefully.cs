namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherFixhopefully : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Caf_CartModel", "MenuItem_MenuID", "Caf_MenuItemModel");
            DropIndex("Caf_CartModel", new[] { "MenuItem_MenuID" });
            RenameColumn(table: "Caf_CartModel", name: "MenuItem_MenuID", newName: "MenuID");
            AlterColumn("Caf_CartModel", "MenuID", c => c.Int(nullable: false));
            CreateIndex("Caf_CartModel", "MenuID");
            AddForeignKey("Caf_CartModel", "MenuID", "Caf_MenuItemModel", "MenuID", cascadeDelete: true);
            DropColumn("Caf_CartModel", "ItemID");
        }
        
        public override void Down()
        {
            AddColumn("Caf_CartModel", "ItemID", c => c.Int(nullable: false));
            DropForeignKey("Caf_CartModel", "MenuID", "Caf_MenuItemModel");
            DropIndex("Caf_CartModel", new[] { "MenuID" });
            AlterColumn("Caf_CartModel", "MenuID", c => c.Int());
            RenameColumn(table: "Caf_CartModel", name: "MenuID", newName: "MenuItem_MenuID");
            CreateIndex("Caf_CartModel", "MenuItem_MenuID");
            AddForeignKey("Caf_CartModel", "MenuItem_MenuID", "Caf_MenuItemModel", "MenuID");
        }
    }
}
