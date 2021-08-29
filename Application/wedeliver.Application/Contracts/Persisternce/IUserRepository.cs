using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;
//using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface IUserRepository
    {
        Task<IdentityUser> CreateUser(CreateRestaurantUserCommand command);
       // Task<IdentityUser> FindByEmailAsync(string email);
        //Task<AuthResult> GenerateJwtToken(IdentityUser user);

        //Task<AuthResult> UserLogin(UserLoginRequest user);

        //Task<AuthResult> VerifyToken(TokenRequest tokenRequest);

        //Task<AuthResult> VerifyFBIdToken(string idToken);
    }
}
