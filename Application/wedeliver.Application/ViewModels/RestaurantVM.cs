using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.ViewModels
{
    public class RestaurantVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string TelphoneNumber { get; set; }
        public Location Location { get; set; }
        public FoodStoreCategory FoodCategory { get; set; }
        public RestaurantRatingVM RestaurantRating { get; set; }
        public StoreOpenTimesVM StoreOpenTimes { get; set; }
        public ResturantWokingStatus ResturantWokingStatus { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string CoverPictureUrl { get; set; }
      
    }
}
