using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Domain;
using wedeliver.Infrastructure.Persistence;

namespace wedeliver.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Food>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //public Task<IEnumerable<Food>> GetFoodById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Food>> GetOrdersByUserName(string userName)
        //{
        //    var orderList = await _dbContext.Foods
        //                           .Where(o => o.Id == userName)
        //                            .ToListAsync();

          
        //    return orderList;
        //}
    }
}
