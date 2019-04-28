namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cateringstuff : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.res_reservations",
            //    c => new
            //        {
            //            res_id = c.Int(nullable: false, identity: true),
            //            ver_code = c.Int(nullable: false),
            //            res_start = c.DateTime(nullable: false, precision: 0),
            //            res_end = c.DateTime(nullable: false, precision: 0),
            //            room_id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.res_id)
            //    .ForeignKey("dbo.res_rooms", t => t.room_id, cascadeDelete: true)
            //    .Index(t => t.room_id);
            
            //CreateTable(
            //    "dbo.res_rooms",
            //    c => new
            //        {
            //            room_id = c.Int(nullable: false, identity: true),
            //            room_name = c.String(unicode: false),
            //            location = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.room_id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.res_reservations", "room_id", "dbo.res_rooms");
            //DropIndex("dbo.res_reservations", new[] { "room_id" });
            //DropTable("dbo.res_rooms");
            //DropTable("dbo.res_reservations");
        }
    }
}
