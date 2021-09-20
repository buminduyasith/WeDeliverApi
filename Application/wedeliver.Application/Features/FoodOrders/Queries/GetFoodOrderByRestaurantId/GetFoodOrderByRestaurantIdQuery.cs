using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.ViewModels;

namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderByRestaurantId
{
    public class GetFoodOrderByRestaurantIdQuery:IRequest<FoodOrderRestaurantVM>
    {
        public int OrderId { get; set; }
        public int RestaurantId { get; set; }
    }
}
