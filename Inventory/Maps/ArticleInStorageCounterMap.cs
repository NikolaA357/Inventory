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
    public class ArticleInStorageCounterMap : EntityTypeConfiguration<ArticleInStorageCounter>
    {
        public ArticleInStorageCounterMap()
        {
            this.ToTable("ArticlesInStorageCounter");

            this.HasKey(t => t.ID);

            this.Property(t => t.ArticleCounter);

            this.HasRequired(t => t.Articles)
                .WithMany(g => g.ArticleInStorageCounters)
                .HasForeignKey<int>(t => t.ArticleID)
                .WillCascadeOnDelete();

            this.HasRequired(t => t.WareHouses)
              .WithMany(g => g.ArticleInStorageCounters)
              .HasForeignKey<int>(t => t.WareHouseID)
              .WillCascadeOnDelete();

        }
    }
}