namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels : DbMigration
    {
        public override void Up()
        {
            DropIndex("Caf_MenuItemModel", new[] { "Title" });
            AlterColumn("Caf_MenuItemModel", "Title", c => c.String(nullable: false, maxLength: 450, storeType: "nvarchar"));
            AlterColumn("Caf_MenuItemModel", "Description", c => c.String(nullable: false, unicode: false));
            AlterColumn("Caf_MenuItemModel", "Category", c => c.String(nullable: false, unicode: false));
            AlterColumn("Caf_InvoiceModel", "Customer_name", c => c.String(maxLength: 160, storeType: "nvarchar"));
            AlterColumn("Caf_InvoiceModel", "Customer_phone", c => c.String(maxLength: 24, storeType: "nvarchar"));
            CreateIndex("Caf_MenuItemModel", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("Caf_MenuItemModel", new[] { "Title" });
            AlterColumn("Caf_InvoiceModel", "Customer_phone", c => c.String(unicode: false));
            AlterColumn("Caf_InvoiceModel", "Customer_name", c => c.String(unicode: false));
            AlterColumn("Caf_MenuItemModel", "Category", c => c.String(unicode: false));
            AlterColumn("Caf_MenuItemModel", "Description", c => c.String(unicode: false));
            AlterColumn("Caf_MenuItemModel", "Title", c => c.String(maxLength: 450, storeType: "nvarchar"));
            CreateIndex("Caf_MenuItemModel", "Title", unique: true);
        }
    }
}
