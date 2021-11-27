using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.ViewModels
{
    public class StoreOpenTimesVM
    {
        public int StartHours { get; set; }
        public int StartMin { get; set; }
        public int EndHours { get; set; }
        public int EndMin { get; set; }
        public int RestaurantId { get; set; }
    }
}
