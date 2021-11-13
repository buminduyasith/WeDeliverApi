﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class FoodCategory : EntityBase
    {
        public string slug { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
