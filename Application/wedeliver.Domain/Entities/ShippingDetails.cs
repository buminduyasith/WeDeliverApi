using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;
using wedeliver.Domain.Enums;

namespace wedeliver.Domain.Entities
{
    public class ShippingDetails: EntityBase
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string HouseNo { get; set; }
        public Provinces Province { get; set; }
        public Districts District { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }

    }
}
