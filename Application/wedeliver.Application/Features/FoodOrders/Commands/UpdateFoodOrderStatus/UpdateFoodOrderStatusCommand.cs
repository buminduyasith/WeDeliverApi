﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.FoodOrders.Commands.UpdateFoodOrderStatus
{
    public class UpdateFoodOrderStatusCommand:IRequest
    {
        public int RestaurantId { get; set; }
        public int OrderId { get; set; }
        public FoodOrderStatus Status { get; set; }
    }
}