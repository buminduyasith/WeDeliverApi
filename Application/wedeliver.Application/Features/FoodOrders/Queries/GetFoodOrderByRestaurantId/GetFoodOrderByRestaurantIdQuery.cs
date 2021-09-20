using MediatR;
using wedeliver.Application.Features.FoodOrders.ViewModels;


namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderByRestaurantId
{
    public class GetFoodOrderByRestaurantIdQuery : IRequest<FoodOrderVM>
    {
        public int RestaurantId { get; set; }

       
    }
}
