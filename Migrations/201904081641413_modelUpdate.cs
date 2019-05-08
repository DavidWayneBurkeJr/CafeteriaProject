namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Caf_MenuItemModel", "Title", c => c.String(maxLength: 450, storeType: "nvarchar"));
            CreateIndex("Caf_MenuItemModel", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("Caf_MenuItemModel", new[] { "Title" });
            AlterColumn("Caf_MenuItemModel", "Title", c => c.String(unicode: false));
        }
    }
}
