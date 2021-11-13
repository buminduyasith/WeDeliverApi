﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodCategory
{
    public class AddFoodCategoryCommand : IRequest<FoodCategoryVM>
    {
        public int Id { get; set; }
        public string slug { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
       

    }
}
