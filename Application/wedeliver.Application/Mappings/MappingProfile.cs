using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using wedeliver.Application.Features.Foods.Commands.AddFoodItem;
using wedeliver.Application.Features.Foods.Commands.UpdateFoodItem;
using wedeliver.Application.ViewModels;
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
            CreateMap<CreateFoodOrderCommand,FoodOrder >().ReverseMap();
            CreateMap<FoodOrder,CreateFoodOrderCommand>().ReverseMap();
            //CreateMap<FoodOrderVM, FoodOrder>().ReverseMap();
            CreateMap<FoodOrderDetails, FoodOrderDetailVM>().ReverseMap();
            CreateMap<Client, ClientVM>().ReverseMap();
            CreateMap<Restaurant, RestaurantVM>().ReverseMap();

            CreateMap<FoodOrder, FoodOrderVM>()
             .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => $"{src.Restaurant.Name} resname"))
             .ForMember(dest => dest.TelphoneNumber, opt => opt.MapFrom(src => src.Restaurant.TelphoneNumber));

            CreateMap<FoodOrder, FoodOrderBackOfficeVM>().ReverseMap();
            CreateMap<FoodOrder, FoodOrderRestaurantVM>().ReverseMap();

            


        }
    }
}
