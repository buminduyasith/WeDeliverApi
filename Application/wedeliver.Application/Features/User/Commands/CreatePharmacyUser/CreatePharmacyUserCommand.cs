using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.User.Commands.CreatePharmacyUser
{
    public class CreatePharmacyUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string? Discription { get; set; }
        public string TelphoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string No { get; set; }
        public Provinces ProvinceId { get; set; }
        public Districts DistrictsId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

    }

    public class CreatePharmacyUserCommandHandler
    {

    }
}
