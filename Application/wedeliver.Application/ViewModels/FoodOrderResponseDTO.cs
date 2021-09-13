using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.commonResponseDTO
{
    public class FoodOrderResponseDTO
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Qty { get; set; }
        public int FoodId { get; set; }

    }
}
