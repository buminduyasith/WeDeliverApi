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

namespace wedeliver.Application.Features.User.Commands.CreateRiderUser
{
    public class CreateRiderUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string No { get; set; }
        public Provinces ProvinceId { get; set; }
        public Districts DistrictsId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string DrivingLicenseUrl { get; set; }

    }
}
