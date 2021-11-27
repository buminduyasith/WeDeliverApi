using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class StoreOpenTimes: EntityBase
    {
        public int StartHours { get; set; }
        public int StartMin { get; set; }
        public int EndHours { get; set; }
        public int EndMin { get; set; }
        
    }
}
