using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class Location: EntityBase
    {
        public string HouseNo { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

    }
}
