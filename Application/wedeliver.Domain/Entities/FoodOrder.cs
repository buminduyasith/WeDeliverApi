using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;
using wedeliver.Domain.Enums;

namespace wedeliver.Domain.Entities
{
    public class FoodOrder: EntityBase
    {
        public string OrderNo { get; set; }
        public double Total { get; set; }
        public int Qty { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public ICollection<FoodOrderDetails> ItemList { get; set; } = new List<FoodOrderDetails>();
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public FoodOrderStatus FoodOrderStatus { get; set; }
        public OrderType OrderType { get; set; }
        public Boolean Piad { get; set; }
        public string Note { get; set; }
        public int? RiderId { get; set; }
        public Rider Rider { get; set; }
        public int ShippingDetailsId { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
