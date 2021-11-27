using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.ViewModels
{
    public class RestaurantRatingVM
    {
        public int RestaurantId { get; set; }
        public int ClientId { get; set; }
        public ClientVM ClientVM { get; set; }
        public RatingType RatingType { get; set; }
        public string Remark { get; set; }
    }
}
