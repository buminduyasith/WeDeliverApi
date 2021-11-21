using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.ViewModels
{
    public class ShippingDetailsVM
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string HouseNo { get; set; }
        public Provinces Province { get; set; }
        public Cities City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }

    }
}
