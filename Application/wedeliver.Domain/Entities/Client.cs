using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class Client: EntityBase
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string PhoneNumber { get; set; }

    }
}
