using MediatR;
using wedeliver.Application.Features.FoodOrders.ViewModels;


namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderById
{
    public class GetFoodOrderByRestaurantIdQuery : IRequest<FoodOrderVM>
    {
        public int Id { get; set; }

        public GetFoodOrderByRestaurantIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
