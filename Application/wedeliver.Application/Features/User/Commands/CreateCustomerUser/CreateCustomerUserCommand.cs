using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.User.Commands.CreateCustomerUser
{
    public class CreateCustomerUserCommand:IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string? No { get; set; }
        public Provinces ProvinceId { get; set; }
        public Districts DistrictsId { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string PhoneNumber { get; set; }
    }
}
