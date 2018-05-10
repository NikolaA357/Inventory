using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class Category
    {

       

        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}