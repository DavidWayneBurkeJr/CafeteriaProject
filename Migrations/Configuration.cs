namespace BatemanCafeteria.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BatemanCafeteria.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BatemanCafeteria.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BatemanCafeteria.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Caf_FoodStatuses.AddOrUpdate(x => x.StatusId,
                new Caf_FoodStatusModel() { StatusId = 1, Status = "Received" },
                new Caf_FoodStatusModel() { StatusId = 2, Status = "Cooking" },
                new Caf_FoodStatusModel() { StatusId = 3, Status = "Ready For Pickup" });
        }
    }
}
