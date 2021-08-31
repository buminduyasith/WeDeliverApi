using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Domain.Enums
{
    public enum FoodOrderStatus
    {
        Pending=1,
        OrderPlaced=2,
        ReadyToPickedUpForRider=3,
        RiderAccepted=4,
        PickedUp=5,
        Delivered=6,
        PAID=7,
        ReadyToPickedUpBuyer = 8,

    }
}
