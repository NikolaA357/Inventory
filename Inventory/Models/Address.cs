using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory.Models
{

    public class Address
    {

        public int ID { get; set; }
        public int PostCode { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public int CityId { get; set; }
        public City Cities { get; set; }

        public ICollection<WareHouse> WareHouses { get; set; }

    }
}