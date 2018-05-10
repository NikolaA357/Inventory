using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class ArticleInStorageCounter
    {
        public int ID { get; set; }
        public int ArticleCounter { get; set; }

        //public ICollection<WareHouse> WareHouses { get; set; }
        //public ICollection<Article> Articles { get; set; }

        public int ArticleID { get; set; }
        public Article Articles { get; set; }

        public int WareHouseID { get; set; }
        public WareHouse WareHouses { get; set; }
    }
}