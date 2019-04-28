namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cateringstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Caf_Caterings",
                c => new
                    {
                        CateringId = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        res_id = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false, precision: 0),
                        Instructions = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CateringId)
                .ForeignKey("Caf_InvoiceModel", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("res_reservations", t => t.res_id, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.res_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Caf_Caterings", "res_id", "dbo.res_reservations");
            DropForeignKey("dbo.Caf_Caterings", "InvoiceID", "dbo.Caf_InvoiceModel");
            DropIndex("dbo.Caf_Caterings", new[] { "res_id" });
            DropIndex("dbo.Caf_Caterings", new[] { "InvoiceID" });
            DropTable("dbo.Caf_Caterings");
        }
    }
}
