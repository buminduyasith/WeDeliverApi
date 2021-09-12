using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface IFoodOrderRepository:IAsyncRepository<FoodOrder>
    {
        Task<FoodOrder> CreateFoodOrder(CreateFoodOrderCommand createFoodOrderCommand, FoodOrder foodOrder);
        Task<Restaurant> GetRestaurantDetails(int id);
    }
}
