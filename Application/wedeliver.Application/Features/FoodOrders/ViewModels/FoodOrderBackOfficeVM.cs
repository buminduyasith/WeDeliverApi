using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.FoodOrders.ViewModels
{
    class FoodOrderBackOfficeVM
    {
        public string OrderNo { get; set; }
        public double Total { get; set; }
        public int Qty { get; set; }
        public ICollection<FoodOrderDetails> ItemList { get; set; } = new List<FoodOrderDetails>();
        public FoodOrderStatus FoodOrderStatus { get; set; }
        public OrderType OrderType { get; set; }
        public string Note { get; set; }
        public Client Client { get; set; }
    }
}
