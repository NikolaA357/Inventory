using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Inventory.Maps;
using Inventory.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Microsoft.Win32;

namespace Inventory.Persistence
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base(@"data source = DESKTOP-BOED0DP; initial catalog = InventoryDB1; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework")
            {
            Database.SetInitializer(new CreateDatabaseIfNotExists<InventoryContext>());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleInStorageCounter> ArticleInStorageCounters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new ArticleInStorageCounterMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new WareHouseMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();
            return base.SaveChanges();
        }
    }
}