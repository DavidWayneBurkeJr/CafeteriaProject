namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Caf_InvoiceModel", "Customer_name", c => c.String(nullable: false, maxLength: 160, storeType: "nvarchar"));
            AlterColumn("Caf_InvoiceModel", "Customer_email", c => c.String(nullable: false, unicode: false));
            AlterColumn("Caf_InvoiceModel", "Customer_phone", c => c.String(nullable: false, maxLength: 24, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Caf_InvoiceModel", "Customer_phone", c => c.String(maxLength: 24, storeType: "nvarchar"));
            AlterColumn("dbo.Caf_InvoiceModel", "Customer_email", c => c.String(unicode: false));
            AlterColumn("dbo.Caf_InvoiceModel", "Customer_name", c => c.String(maxLength: 160, storeType: "nvarchar"));
        }
    }
}
