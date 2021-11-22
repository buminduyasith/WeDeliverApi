using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;
using wedeliver.Domain.Enums;

namespace wedeliver.Domain.Entities
{
    public class Restaurant:EntityBase
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Discription { get; set; }
        public string TelphoneNumber { get; set; }
        public string  PersonalPhoneNumber { get; set; }
        private int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<Food> Foods { get; set; } = new List<Food>();
        public FoodStoreCategory FoodCategory { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string CoverPictureUrl { get; set; }
        public string StoreHours { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public RestaurantRating RestaurantRating { get; set; }
        public StoreOpenTimes StoreOpenTimes { get; set; }



    }
}
