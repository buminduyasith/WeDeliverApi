using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
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
    }
}
