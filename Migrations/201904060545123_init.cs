namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CartModels",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        CartID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID);
            
            CreateTable(
                "InvoiceModels",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        Customer_name = c.String(unicode: false),
                        Customer_email = c.String(unicode: false),
                        Customer_phone = c.String(unicode: false),
                        Order_date = c.DateTime(nullable: false, precision: 0),
                        Order_time = c.String(unicode: false),
                        Order_total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Payment_status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "OrderItemModels",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Special_instructions = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("InvoiceModels", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "MenuItemModels",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(unicode: false),
                        Calories = c.Int(nullable: false),
                        ImgLocation = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //            Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //            RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //            Email = c.String(maxLength: 256, storeType: "nvarchar"),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(unicode: false),
            //            SecurityStamp = c.String(unicode: false),
            //            PhoneNumber = c.String(unicode: false),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(precision: 0),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //            ClaimType = c.String(unicode: false),
            //            ClaimValue = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //            ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //            UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderItemModels", "InvoiceID", "dbo.InvoiceModels");
            //DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            //DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            //DropIndex("dbo.AspNetUsers", "UserNameIndex");
            //DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            //DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            //DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderItemModels", new[] { "InvoiceID" });
            //DropTable("dbo.AspNetUserLogins");
            //DropTable("dbo.AspNetUserClaims");
            //DropTable("dbo.AspNetUsers");
            //DropTable("dbo.AspNetUserRoles");
            //DropTable("dbo.AspNetRoles");
            DropTable("dbo.MenuItemModels");
            DropTable("dbo.OrderItemModels");
            DropTable("dbo.InvoiceModels");
            DropTable("dbo.CartModels");
        }
    }
}
