using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wedeliver.Domain.Common;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Domain
{
    public class Food:EntityBase
    {
       
        public string Name { get; set; }
        public string Discription { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int RestaurantId { get; set; }

       // [JsonIgnore]
        public Restaurant Restaurant { get; set; }



    }
}
