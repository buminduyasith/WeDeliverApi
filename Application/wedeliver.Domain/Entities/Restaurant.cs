using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class Restaurant:EntityBase
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public string  PhoneNumber { get; set; }
        public string City { get; set; }
        public Guid UserId { get; set; }
       

    }
}
