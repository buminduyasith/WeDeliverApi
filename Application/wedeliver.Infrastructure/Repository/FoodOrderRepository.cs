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

        public async Task<FoodOrder> CreateFoodOrder(CreateFoodOrderCommand createFoodOrderCommand,FoodOrder foodOrder)
        {
            var list = createFoodOrderCommand.ItemList;
            var totalPrice = 0.00;

            foreach (var item in list)
            {
               var foodItem = await  _dbContext.Foods.Where(food => food.Id == item.FoodId).FirstOrDefaultAsync();
                totalPrice += foodItem.Price;
            }


            foodOrder.Total = totalPrice;
            //var CreatedFooditem = await AddAsync(foodOrder);
            //var orderList = await _dbContext.FoodOrder
            //                        .Where(o => o.UserName == userName)
            //                        .ToListAsync();
            return foodOrder;
        }

    }
}
