using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.User.ViewModels;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.User.Commands.CreateRestaurantUser
{
    //public class CreateRestaurantUserCommand : IRequest<IdentityUser>
    public class CreateRestaurantUserCommand:IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string StoreName { get; set; }
        public string OwnerName { get; set; }
        public string Discription { get; set; }
        public string TelphoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string HouseNo { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public FoodStoreCategory FoodCategory { get; set; }

    }
}
