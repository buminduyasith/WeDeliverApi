using MediatR;
using wedeliver.Application.Features.FoodOrders.ViewModels;


namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderById
{
    public class GetFoodOrderByIdQuery : IRequest<FoodOrderVM>
    {
        public int Id { get; set; }

       
    }
}
