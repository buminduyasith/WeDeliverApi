using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Features.FoodOrder.Commands.CreateFoodOrder
{
    public class FoodOrderRequestDto
    {
        public int FoodId { get; set; }
        public int Qty { get; set; }
    }
}
