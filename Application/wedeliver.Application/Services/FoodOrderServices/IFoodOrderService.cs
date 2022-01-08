using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Services.FoodOrderServices
{
    public interface IFoodOrderService
    {
        Task<FoodOrderVM> CreateFoodOrder(CreateFoodOrderCommand createFoodOrderCommand);

        Task<bool> SaveInvoiceDownloadableURL(string url,int id);

    }
}
