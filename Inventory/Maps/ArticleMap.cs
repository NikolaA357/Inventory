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
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
       
        public ArticleMap()
        {
            this.ToTable("Articles");

            this.HasKey(t => t.ID);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.TextField)
                .HasMaxLength(30);

            this.Property(t => t.PhotographyOfArticle)
               .HasColumnType("image");

            this.Property(t => t.MemeType)
                .HasMaxLength(30);

            this.HasRequired(t => t.Categories) 
                .WithMany(g => g.Articles)
                .HasForeignKey<int>(t => t.CategoryId)
                .WillCascadeOnDelete();                      

            

           //this.HasRequired(t => t.WareHouses)
           //   .WithMany(t => t.Articles)
           //   .HasForeignKey<int>(t => t.WareHouseId)
           //   .WillCascadeOnDelete(false);

        }
    }
}