using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class FoodOrderDetails:EntityBase
    {
        public double Price { get; set; }
        public int Qty { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
      


    }
}
