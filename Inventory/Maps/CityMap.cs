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
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            this.ToTable("Cities");

            this.HasKey(t => t.ID);

            this.Property(t => t.Name)
                .HasMaxLength(25);

            this.HasRequired(t => t.Couyntries)
                .WithMany(g => g.Citys)
                .HasForeignKey<int>(t => t.CountryId)
                .WillCascadeOnDelete();
        }
    }
}