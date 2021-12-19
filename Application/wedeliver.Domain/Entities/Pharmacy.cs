using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class Pharmacy: EntityBase
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Discription { get; set; }
        public string TelphoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public int? LocationId { get; set; }
        public Location Location { get; set; }
       
    }
}
