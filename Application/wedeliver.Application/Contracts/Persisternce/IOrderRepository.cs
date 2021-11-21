using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface IOrderRepository:IAsyncRepository<Food>
    {
        //Task<IEnumerable<Food>> GetFoodByI(int id);

    }
}
