﻿using AutoMapper;
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

        public async Task<IdentityUser> CreateUser(CreateRestaurantUserCommand user)
        {
           
            var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);
            

            if (isCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "restaurant");
                var restaurantUser = new Restaurant {Name="test",Discription="test 1",City="matara",UserId=Guid.Parse(newUser.Id) };
                _dbContext.Restaurants.Add(restaurantUser);
                await _dbContext.SaveChangesAsync();
                return newUser;

            }

            else
            {
                // TODO: what if user not created propely or something went wrong in the database

                throw new Exception("user not created");
            }
        }

        
    }
}
