namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditModelNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "InvoiceModels", newName: "Caf_InvoiceModel");
            RenameTable(name: "OrderItemModels", newName: "Caf_OrderItemModel");
            RenameTable(name: "MenuItemModels", newName: "Caf_MenuItemModel");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Caf_MenuItemModel", newName: "MenuItemModels");
            RenameTable(name: "dbo.Caf_OrderItemModel", newName: "OrderItemModels");
            RenameTable(name: "dbo.Caf_InvoiceModel", newName: "InvoiceModels");
            RenameTable(name: "dbo.Caf_CartModel", newName: "CartModels");
        }
    }
}
