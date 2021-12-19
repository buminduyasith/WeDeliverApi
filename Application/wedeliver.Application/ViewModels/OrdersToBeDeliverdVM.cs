using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.ViewModels;

namespace wedeliver.Application.ViewModels
{
    public class OrdersToBeDeliverdVM
    {
        public List<FoodOrderRestaurantVM> FoodOrderDetails { get; set; }
        public List<MedicineOrderVM> MedicineOrders { get; set; }
    }
}
