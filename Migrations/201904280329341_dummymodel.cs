namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dummymodel : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.res_reservations", "room_id", "dbo.res_rooms");
            //DropIndex("dbo.res_reservations", new[] { "room_id" });
            //AddColumn("dbo.res_reservations", "user_id", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "email_addr", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "phone_ext", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "res_dt", c => c.DateTime(nullable: false, precision: 0));
            //AddColumn("dbo.res_reservations", "res_name", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "cat_ind", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "cat_order", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "pending_ind", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "approved_ind", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "reject_ind", c => c.String(unicode: false));
            //AddColumn("dbo.res_reservations", "audit_create_dt", c => c.DateTime(nullable: false, precision: 0));
            //AddColumn("dbo.res_reservations", "void_ind", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.res_reservations", "void_ind");
            //DropColumn("dbo.res_reservations", "audit_create_dt");
            //DropColumn("dbo.res_reservations", "reject_ind");
            //DropColumn("dbo.res_reservations", "approved_ind");
            //DropColumn("dbo.res_reservations", "pending_ind");
            //DropColumn("dbo.res_reservations", "cat_order");
            //DropColumn("dbo.res_reservations", "cat_ind");
            //DropColumn("dbo.res_reservations", "res_name");
            //DropColumn("dbo.res_reservations", "res_dt");
            //DropColumn("dbo.res_reservations", "phone_ext");
            //DropColumn("dbo.res_reservations", "email_addr");
            //DropColumn("dbo.res_reservations", "user_id");
            //CreateIndex("dbo.res_reservations", "room_id");
            //AddForeignKey("dbo.res_reservations", "room_id", "dbo.res_rooms", "room_id", cascadeDelete: true);
        }
    }
}
