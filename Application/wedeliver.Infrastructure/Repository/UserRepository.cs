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
using wedeliver.Application.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            using var transaction = _dbContext.Database.BeginTransaction();

            IdentityUser newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);
            

            if (isCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.RestaurantAdmin.ToString());
                
                var restaurantUser = new Restaurant {
                    Name=user.StoreName,
                    OwnerName = user.OwnerName,
                    Discription = user.Discription,
                    FoodCategory =  user.FoodCategory,
                    Active=false,
                    PersonalPhoneNumber = user.PersonalPhoneNumber,
                    TelphoneNumber = user.TelphoneNumber,
                    UserId = newUser.Id,
                    Location = new Location
                    {
                        HouseNo=user.HouseNo,
                        Province = user.ProvinceId.ToString(),
                        City = user.City,
                        Street = user.Street,
                        ProvinceID = user.ProvinceId,
                        Districts = user.DistrictsId
                    },
                    StoreOpenTimes = new StoreOpenTimes
                    {
                      StartHours = (int)(user.StartHours!=null?user.StartHours:0),
                      EndHours = (int)(user.EndHourse != null ? user.EndHourse : 0),
                      StartMin = 0,
                      EndMin = 0,

                    },
                    StoreHours = $"{user.StartHours}:00 - {user.EndHourse}:00",
                    ProfilePictureUrl=user.ProfilePictureUrl
                    
                };
                _dbContext.Restaurants.Add(restaurantUser);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return;

            }

            else
            {
                // TODO: what if user not created propely or something went wrong in the database

                throw new Exception("user not created");
            }
        }

        public async Task CreateCustomerUser(CreateCustomerUserCommand user)
        {
            var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);


            if (isCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.Client.ToString());

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
                await _userManager.AddToRoleAsync(newUser, UserRoles.Rider.ToString());

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

        public async Task<IdentityUser> FindByEmailAsync(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            return existingUser;
        }

        public async Task<UserVM> UserLogin(string email, string password)
        {
            var user = await FindByEmailAsync(email);

            if( user != null)
            {

                var isSuccessLogin = await _userManager.CheckPasswordAsync(user, password);

                if (isSuccessLogin)
                {

                    var userRole =await  _userManager.GetRolesAsync(user);  //await _dbContext.UserRoles.FindAsync();

                    UserVM uservm = null;

                    if (userRole.Contains(UserRoles.RestaurantAdmin.ToString()))
                    {
                        var restaurantUser = await _dbContext.Restaurants.Where(res => res.UserId == user.Id).FirstOrDefaultAsync();

                        uservm = new UserVM
                        {
                            email = user.Email,
                            UserRole = userRole,
                            UserIdentityId = user.Id,
                            Id = restaurantUser.Id

                        };
                    }

                    else if (userRole.Contains(UserRoles.Client.ToString()))
                    {
                        var client = await _dbContext.Clients.Where(res => res.UserId == user.Id).FirstOrDefaultAsync();

                        uservm = new UserVM
                        {
                            email = user.Email,
                            UserRole = userRole,
                            UserIdentityId = user.Id,
                            Id = client.Id,
                            Name=client.FName

                        };
                    }

                    else if (userRole.Contains(UserRoles.Rider.ToString()))
                    {
                        var Riders = await _dbContext.Riders.Where(res => res.UserId == user.Id).FirstOrDefaultAsync();
                        uservm = new UserVM
                        {
                            email = user.Email,
                            UserRole = userRole,
                            UserIdentityId = user.Id,
                            Id = Riders.Id,
                            Name = Riders.FName

                        };

                    }

                    return uservm;

                 

                   
                }
                else
                {
                    throw new Exception("username or password is incorrect");
                }

               
            }

            else
            {
                throw new Exception("Invalid User");
            }
        }

    }
}
