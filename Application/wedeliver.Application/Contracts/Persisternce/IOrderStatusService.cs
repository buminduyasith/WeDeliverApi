using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.Commands.RiderAcceptOrder;
using wedeliver.Application.Features.FoodOrders.Commands.UpdateFoodOrderStatus;
using wedeliver.Application.Features.FoodOrders.ViewModels;
//using wedeliver.Domain.Entities;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface IOrderStatusService
    {
        Task<Unit> updateOrderStatusFromRestaurant(UpdateFoodOrderStatusCommand updateFoodOrderStatusCommand);
        Task<Unit> updateOrderStatusFromRider(UpdateFoodOrderStatusCommand updateFoodOrderStatusCommand);
        Task<IEnumerable<FoodOrderVM>> GetAllAvailableOrdersForRider();
        Task<Boolean> RiderOrderAcceptToDeliver(RiderAcceptOrderCommand riderAcceptOrderCommand);



    }
}
