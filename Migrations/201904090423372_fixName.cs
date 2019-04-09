namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "FoodStatusModels", newName: "Caf_FoodStatusModel");
        }
        
        public override void Down()
        {
            RenameTable(name: "Caf_FoodStatusModel", newName: "FoodStatusModels");
        }
    }
}
