using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using wedeliver.Domain.Entities;
using wedeliver.Infrastructure.Persistence;
using wedeliver.Infrastructure.Repositories;

namespace wedeliver.Infrastructure.Repository
{
    public class FoodOrderRepository : RepositoryBase<FoodOrder>, IFoodOrderRepository
    {
        public FoodOrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<FoodOrder> CreateFoodOrder(CreateFoodOrderCommand createFoodOrderCommand, FoodOrder foodOrder)
        {
            throw new NotImplementedException();
        }

        public async Task<Restaurant> GetRestaurantDetails(int id)
        {
            var restaurant =await  _dbContext.Restaurants.Where(res => res.Id == id).FirstOrDefaultAsync();
            return restaurant;
        }
    }
}
