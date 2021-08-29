using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain
{
    public class Food:EntityBase
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public double Price { get; set; }


    }
}
