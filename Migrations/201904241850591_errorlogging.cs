namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorlogging : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.error_log",
            //    c => new
            //        {
            //            log_id = c.Int(nullable: false, identity: true),
            //            app_name = c.String(unicode: false),
            //            controller = c.String(unicode: false),
            //            method_name = c.String(unicode: false),
            //            error_mes = c.String(unicode: false),
            //            audit_create_dt = c.DateTime(nullable: false, precision: 0),
            //        })
            //    .PrimaryKey(t => t.log_id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.error_log");
        }
    }
}
