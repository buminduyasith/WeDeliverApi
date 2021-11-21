using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.ViewModels
{
    public class FoodOrderDetailVM
    {
        public double Price { get; set; }
        public int Qty { get; set; }
        public int FoodId { get; set; }
        public FoodVM Food { get; set; }
    }
}
