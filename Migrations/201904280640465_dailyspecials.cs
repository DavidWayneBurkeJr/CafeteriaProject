namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dailyspecials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Caf_DailySpecials",
                c => new
                    {
                        SpecialId = c.Int(nullable: false, identity: true),
                        MenuID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialId)
                .ForeignKey("Caf_MenuItemModel", t => t.MenuID, cascadeDelete: true)
                .Index(t => t.MenuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Caf_DailySpecials", "MenuID", "Caf_MenuItemModel");
            DropIndex("Caf_DailySpecials", new[] { "MenuID" });
            DropTable("Caf_DailySpecials");
        }
    }
}
