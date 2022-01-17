using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;

namespace wedeliver.webapi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly HttpContext _context;
       
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor.HttpContext;
        }

        public IEnumerable<Claim> Claims
        {
            get
            {
                return (_context.User.Identity as ClaimsIdentity).Claims;
            }
        }

       
       
        public string UserEmail
        {
            get
            {
                return Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;
            }
        }

        public string IdentityId
        {
            get
            {
                return Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;
            }
        }

        public string Name
        {
            get
            {
                return Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            }
        }

        public string Id
        {
            get
            {
                return Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            }
        }

        public string Role
        {
            get
            {
                return Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            }
        }



        //public string UserName
        //{
        //    get
        //    {
        //        return Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value;
        //    }
        //}


        //public DateTime DOB
        //{
        //    get
        //    {
        //        var dateValue = Claims.FirstOrDefault(c => c.Type == "DateOfBirth")?.Value;
        //        DateTime.TryParse(dateValue, out DateTime dateTime);

        //        return dateTime;
        //    }
        //}

        //public UserType UserType
        //{
        //    get
        //    {
        //        var userType = Claims.FirstOrDefault(c => c.Type == "userType");
        //        return userType == null ? UserType.Anonymous : userType.Value.ToEnum<UserType>();
        //    }
        //}
    }
}
