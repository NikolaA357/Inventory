using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class WareHouse
    {

       
        public int ID { get; set; }
        public string Name { get; set; }
        public int SurfaceArea { get; set; }
        public string Note { get; set; }

        //public ICollection<Article> Articles { get; set; }

        public int AddressId { get; set; }
        public  Address Addresses { get; set; }

        //public int ArticleCounterId { get; set; }
        //public ArticleInStorageCounter ArticleInStorageCounters { get; set; }

        public ICollection<ArticleInStorageCounter> ArticleInStorageCounters { get; set; }
    }
}