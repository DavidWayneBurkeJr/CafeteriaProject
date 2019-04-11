namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Caf_InvoiceModel", "Order_date", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Caf_InvoiceModel", "Order_date", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
