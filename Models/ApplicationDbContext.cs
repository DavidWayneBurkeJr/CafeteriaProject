using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BatemanCafeteria.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        #region tables
        public virtual DbSet<Caf_InvoiceModel> Caf_Invoices { get; set; }
        public virtual DbSet<Caf_CartModel> Caf_Carts { get; set; }
        public virtual DbSet<Caf_OrderItemModel> Caf_OrderItems { get; set; }
        public virtual DbSet<Caf_MenuItemModel> Caf_MenuItems { get; set; }
        public virtual DbSet<Caf_FoodStatusModel> Caf_FoodStatuses { get; set; }
        #endregion tables

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}