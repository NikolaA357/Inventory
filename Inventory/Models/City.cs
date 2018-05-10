using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Couyntries { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}