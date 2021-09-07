using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using wedeliver.Application.Features.User.Commands.CreateCustomerUser;
using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;
using wedeliver.Application.Features.User.Commands.CreateRiderUser;
//using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface IUserRepository
    {
        //Task<IdentityUser> CreateRestaurantUser(CreateRestaurantUserCommand command);
        Task CreateRestaurantUser(CreateRestaurantUserCommand command);
        Task CreateCustomerUser(CreateCustomerUserCommand command);
        Task CreateRiderrUser(CreateRiderUserCommand command);

        Task<IdentityUser> FindByEmailAsync(string email);
       // Task<IdentityUser> FindByEmailAsync(string email);
        //Task<AuthResult> GenerateJwtToken(IdentityUser user);

        //Task<AuthResult> UserLogin(UserLoginRequest user);

        //Task<AuthResult> VerifyToken(TokenRequest tokenRequest);

        //Task<AuthResult> VerifyFBIdToken(string idToken);
    }
}
