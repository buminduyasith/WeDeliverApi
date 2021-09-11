using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrder.ViewModels;
using wedeliver.Application.Features.Foods.Commands.AddFoodItem;
using wedeliver.Application.Features.Foods.Commands.UpdateFoodItem;
using wedeliver.Application.Features.Foods.ViewModels;
using wedeliver.Domain;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Food, FoodVM>().ReverseMap();
            CreateMap<Food, AddFoodItemCommand>().ReverseMap();
            CreateMap<Food, UpdateFoodItemCommand>().ReverseMap();
            CreateMap<FoodOrder, FoodOrderVM>().ReverseMap();
        }
    }
}
