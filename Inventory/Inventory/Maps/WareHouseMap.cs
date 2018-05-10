using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using Inventory.Models;
using System.Web;

namespace Inventory.Maps
{
    public class WareHouseMap : EntityTypeConfiguration<WareHouse>
    {
        public WareHouseMap()
        {
            this.ToTable("WareHouses");


            this.HasKey(t => t.ID);

            this.Property(t => t.Name)
                .HasMaxLength(25);

            this.Property(t => t.SurfaceArea);

            this.Property(t => t.Note)
                .HasMaxLength(100);

            this.HasRequired(t => t.Addresses)
                 .WithMany(g => g.WareHouses)
                 .HasForeignKey<int>(t => t.AddressId)
                 .WillCascadeOnDelete();

           
        }
    }
}