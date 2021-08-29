using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodItem
{
    public class AddFoodItemCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
    }
}
