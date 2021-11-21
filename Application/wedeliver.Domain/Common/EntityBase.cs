using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool Active { get; set; }


    }
}
