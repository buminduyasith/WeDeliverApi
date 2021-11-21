using MediatR;
using wedeliver.Application.Features.FoodOrders.ViewModels;


namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderByOrderNo
{
    public class GetFoodOrderByOrderNoQuery : IRequest<FoodOrderVM>
    {
        public string OrderNO { get; set; }

        public GetFoodOrderByOrderNoQuery(string OrderNO)
        {
            this.OrderNO = OrderNO;
        }
    }
}
