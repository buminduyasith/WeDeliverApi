using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Features.Foods.Commands.UpdateFoodItem
{
    public class UpdateFoodItemCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
    }
}
