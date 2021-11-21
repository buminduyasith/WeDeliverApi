using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Domain;
using wedeliver.Infrastructure.Persistence;
using wedeliver.Infrastructure.Repositories;

namespace wedeliver.Infrastructure.Repository
{
    public class FoodRepository: RepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        //{
        //    var orderList = await _dbContext.Orders
        //                            .Where(o => o.UserName == userName)
        //                            .ToListAsync();
        //    return orderList;
        //}
    }
}
