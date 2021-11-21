using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.FoodOrders.ViewModels
{
    public class FoodOrderVM
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public double Total { get; set; }
        public int Qty { get; set; }
        public int ClientID { get; set; }
        public ICollection<FoodOrderDetailVM> ItemList { get; set; } = new List<FoodOrderDetailVM>();
        public FoodOrderStatus FoodOrderStatus { get; set; }
        public OrderType OrderType { get; set; }
        public string Note { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
        public string TelphoneNumber { get; set; }
    }
}
