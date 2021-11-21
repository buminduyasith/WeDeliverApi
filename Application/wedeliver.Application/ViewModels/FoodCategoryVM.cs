using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.ViewModels
{
    public class FoodCategoryVM
    {
        public int Id { get; set; }
        public string slug { get; set; }
        public string Name { get; set; }
        public string  Text { get; set; }
        public string Value { get; set; }

    }
}
