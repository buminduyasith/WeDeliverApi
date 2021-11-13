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
        BeingPrepared=3,
        ReadyToPickedUpForRider =4,
        RiderAccepted=5,
        PickedUp=6,
        Delivered=7,
        PAID=8,
        ReadyToPickedUpBuyer = 9,
        CANCELED = 10,


    }
}
