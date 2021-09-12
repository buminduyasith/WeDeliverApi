using MediatR;
using wedeliver.Application.Features.FoodOrders.ViewModels;


namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderByRestaurantId
{
    public class GetFoodOrderByRestaurantIdQuery : IRequest<FoodOrderVM>
    {
        public int restaurantId { get; set; }

        public GetFoodOrderByRestaurantIdQuery(int restaurantId)
        {
            this.restaurantId = restaurantId;
        }
    }
}
