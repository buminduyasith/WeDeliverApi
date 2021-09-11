using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrder.ViewModels;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.FoodOrder.Commands.CreateFoodOrder
{
    public class CreateFoodOrderCommand:IRequest<FoodOrderVM>
    {
        public int ClientID { get; set; }
        public int RestaurantId { get; set; }
        public ICollection<FoodOrderRequestDto> ItemList { get; set; } = new List<FoodOrderRequestDto>();
        public OrderType OrderType { get; set; }
        public string Note { get; set; }





    }
}
