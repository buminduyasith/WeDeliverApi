using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodItem
{
    public class AddFoodItemCommand:IRequest<FoodVM>
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int FoodCategoryId { get; set; }
       

    }
}
