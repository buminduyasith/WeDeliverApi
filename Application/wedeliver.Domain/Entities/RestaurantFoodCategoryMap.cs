using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class RestaurantFoodCategoryMap : EntityBase
    {
        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
