using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class Article
    {   
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] PhotographyOfArticle { get; set; }
        public string MemeType { get; set; }
        public string TextField { get; set; }
       
        public string base64 { get
            {
                if (PhotographyOfArticle == null)
                    return "No image";
                else
                    //return ("data: image / " + MemeType + "; base64, " + Convert.ToBase64String(PhotographyOfArticle)).Replace(" ", "").Replace("\n", "");
                    return (MemeType + "," + Convert.ToBase64String(PhotographyOfArticle)).Replace(" ", "").Replace("\n", "");
            }
        }

       //public int WareHouseId { get; set; }
       //public WareHouse WareHouses { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }
       
        //public int ArticleCounterId { get; set; }
        //public ArticleInStorageCounter ArticleInStorageCounters { get; set; }

        public ICollection<ArticleInStorageCounter> ArticleInStorageCounters { get; set; }

    }

    //ublic class UpArticle
    //
    //   public string Name { get; set; }
    //   public string PhotographyOfArticle { get; set; }
    //   public string TextField { get; set; }
    //   public int CategoryId { get; set; }
    //
    //   public Article toArticle()
    //   {
    //       Article a = new Article();
    //       a.Name = Name;
    //       a.TextField = TextField;
    //       a.CategoryId = CategoryId;
    //
    //       PhotographyOfArticle = PhotographyOfArticle.Replace('-', '+');
    //       PhotographyOfArticle = PhotographyOfArticle.Replace('_', '/');
    //       a.PhotographyOfArticle = Convert.FromBase64String(PhotographyOfArticle);

   // Image image = Base64ToImage(pdfString);
   // byte[] imageData = ToBase64(image, ImageFormat.Png);
   // string contentType = "image/png";
   // var path = Path.Combine(Server.MapPath("~/Content/Images/"));
   // image.Save(path+"/ShowImage.png");           
   //         return new FileContentResult(imageData, "image/png");
    //
    //        return a;
    //    }
    //}
}