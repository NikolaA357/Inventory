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
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.ToTable("Addresses");

            this.HasKey(t => t.ID);

            this.Property(t => t.StreetName)
                .HasMaxLength(25);

            this.Property(t => t.PostCode);

            this.Property(t => t.HouseNumber);


            this.HasRequired(t => t.Cities)
                 .WithMany(g => g.Addresses)
                 .HasForeignKey<int>(t => t.CityId)
                 .WillCascadeOnDelete();                     

        }
    }
}