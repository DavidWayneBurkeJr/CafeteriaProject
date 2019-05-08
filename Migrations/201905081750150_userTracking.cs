namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userTracking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Caf_ServiceUsers",
                c => new
                    {
                        ServiceUsersId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, unicode: false),
                        MachineName = c.String(nullable: false, unicode: false),
                        DomainName = c.String(nullable: false, unicode: false),
                        IsBanned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceUsersId);
            
            AddColumn("Caf_InvoiceModel", "Username", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("Caf_InvoiceModel", "Username");
            DropTable("Caf_ServiceUsers");
        }
    }
}
