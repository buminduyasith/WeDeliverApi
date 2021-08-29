using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.User.ViewModels;

namespace wedeliver.Application.Features.User.Commands.CreateRestaurantUser
{
    public class CreateRestaurantUserCommand:IRequest<IdentityUser>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
       
    }
}
