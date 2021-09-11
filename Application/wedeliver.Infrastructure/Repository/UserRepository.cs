using AutoMapper;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using wedeliver.Application.Features.User.Commands.CreateRestaurantUser;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Infrastructure.Persistence;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;
using wedeliver.Application.Features.User.Commands.CreateCustomerUser;
using wedeliver.Application.Features.User.Commands.CreateRiderUser;

namespace wedeliver.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
      
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        protected readonly ApplicationDbContext _dbContext;



        public UserRepository(
             UserManager<IdentityUser> userManager,
            IMapper mapper, ILogger<UserRepository> logger, ApplicationDbContext dbContext)

        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); 
        }

        public async Task CreateRestaurantUser(CreateRestaurantUserCommand user)
        {
           

            IdentityUser newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);
            

            if (isCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.RestaurantAdmin.ToString());
                
                var restaurantUser = new Restaurant {
                    Name=user.StoreName,
                    OwnerName = user.OwnerName,
                    Discription = user.Discription,
                    FoodCategory = user.FoodCategory,
                    Active=false,
                    PersonalPhoneNumber = user.PersonalPhoneNumber,
                    TelphoneNumber = user.TelphoneNumber,
                    UserId = newUser.Id,
                    Location = new Location
                    {
                        HouseNo=user.HouseNo,
                        Province = user.Province,
                        City = user.City,
                        Street = user.Street,
                        
                    }
                    
                };
                _dbContext.Restaurants.Add(restaurantUser);
                await _dbContext.SaveChangesAsync();
                return;

            }

            else
            {
                // TODO: what if user not created propely or something went wrong in the database

                throw new Exception("user not created");
            }
        }

        public async Task<IdentityUser> FindByEmailAsync(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            return existingUser;
        }

        public async Task CreateCustomerUser(CreateCustomerUserCommand user)
        {
            var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);


            if (isCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.RestaurantAdmin.ToString());

                var client = new Client
                {
                    
                    UserId = newUser.Id,
                    FName = user.FName,
                    LName = user.LName,
                    PhoneNumber = user.PhoneNumber,
                    Active = true,
                    Location = new Location
                    {
                        HouseNo = user.HouseNo,
                        Province = user.Province,
                        City = user.City,
                        Street = user.Street,

                    }

                };
                _dbContext.Clients.Add(client);
                await _dbContext.SaveChangesAsync();
                return;

            }

            else
            {
                // TODO: what if user not created propely or something went wrong in the database

                throw new Exception("user not created");
            }
        }

        public async Task CreateRiderrUser(CreateRiderUserCommand user)
        {
            var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);


            if (isCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.RestaurantAdmin.ToString());

                var rider = new Rider
                {

                    UserId = newUser.Id,
                    FName = user.FName,
                    LName = user.LName,
                    PersonalPhoneNumber = user.PersonalPhoneNumber,
                    DrivingLicenseUrl=user.DrivingLicenseUrl,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    Active = true,
                    Location = new Location
                    {
                        HouseNo = user.HouseNo,
                        Province = user.Province,
                        City = user.City,
                        Street = user.Street,

                    }

                };
                _dbContext.Riders.Add(rider);
                await _dbContext.SaveChangesAsync();
                return;

            }

            else
            {
                // TODO: what if user not created propely or something went wrong in the database

                throw new Exception("user not created");
            }
        }
    }
}
