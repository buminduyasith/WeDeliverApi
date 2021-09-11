using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface IFoodOrderRepository:IAsyncRepository<FoodOrder>
    {
    }
}
