using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class OrderReport:EntityBase
    {
        public int OrderId { get; set; }
        public FoodOrder Order { get; set; }
        public string InvoiceUrl { get; set; }
    }
}
