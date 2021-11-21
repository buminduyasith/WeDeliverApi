using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;
using wedeliver.Domain.Enums;

namespace wedeliver.Domain.Entities
{
    public class RestaurantRating: EntityBase
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public RatingType RatingType { get; set; }
        public string Remark { get; set; }
    }
}
