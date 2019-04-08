namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherFixhopefully : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("Caf_CartModel", "MenuItem_MenuID", "Caf_MenuItemModel");
            //DropIndex("Caf_CartModel", new[] { "MenuItem_MenuID" });
            //RenameColumn(table: "Caf_CartModel", name: "MenuItem_MenuID", newName: "MenuID");
            //AlterColumn("Caf_CartModel", "MenuID", c => c.Int(nullable: false));
            CreateIndex("Caf_CartModel", "MenuID");
            AddForeignKey("Caf_CartModel", "MenuID", "Caf_MenuItemModel", "MenuID", cascadeDelete: true);
            DropColumn("Caf_CartModel", "ItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Caf_CartModel", "ItemID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Caf_CartModel", "MenuID", "dbo.Caf_MenuItemModel");
            DropIndex("dbo.Caf_CartModel", new[] { "MenuID" });
            AlterColumn("dbo.Caf_CartModel", "MenuID", c => c.Int());
            RenameColumn(table: "dbo.Caf_CartModel", name: "MenuID", newName: "MenuItem_MenuID");
            CreateIndex("dbo.Caf_CartModel", "MenuItem_MenuID");
            AddForeignKey("dbo.Caf_CartModel", "MenuItem_MenuID", "dbo.Caf_MenuItemModel", "MenuID");
        }
    }
}
