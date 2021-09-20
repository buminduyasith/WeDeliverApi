using MediatR;
using System.Collections.Generic;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrderByRestaurantId
{
    public class GetAllFoodOrderByRestaurantIdQuery : IRequest<IEnumerable<FoodOrderRestaurantVM>>
    {
        public int RestaurantId { get; set; }

       
    }
}
