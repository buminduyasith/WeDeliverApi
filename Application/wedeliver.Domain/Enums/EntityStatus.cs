using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Domain.Enums
{
    public enum EntityStatus
    {
        Active = 1,
        Returned = 2,
        Resubmit = 3,
        Rejected = 4,
        Approved = 5,
        Closed = 6,
        Pending = 7,
    }
}
