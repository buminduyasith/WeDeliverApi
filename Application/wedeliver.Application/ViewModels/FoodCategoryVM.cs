using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.ViewModels
{
    public class FoodCategoryVM
    {
        public int Id { get; set; }
        public string slug { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
    }
}
