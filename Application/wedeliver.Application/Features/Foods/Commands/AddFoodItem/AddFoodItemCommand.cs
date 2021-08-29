using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.Foods.ViewModels;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodItem
{
    public class AddFoodItemCommand:IRequest<FoodVM>
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
    }
}
