using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Domain;
using wedeliver.Infrastructure.Repositories;

namespace wedeliver.Infrastructure.Repository
{
    public class MockOrderRepository : MockRepositoryBase<Food>, IOrderRepository
    {
        //public Task<IEnumerable<Food>> GetFoodById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Food>> GetOrdersByUserName(string userName)
        //{

        //    throw new NotImplementedException();
        //}
    }
}
