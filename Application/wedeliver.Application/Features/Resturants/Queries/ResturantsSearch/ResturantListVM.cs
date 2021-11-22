using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;

namespace wedeliver.Application.Features.Resturants.Queries.ResturantsSearch
{
    public class ResturantListVM
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int TotalItems { get; set; }
        public int NumberOfPages { get; internal set; }
        public int DisplayStart { get; set; }
        public int DisplayEnd { get; set; }
        public int DisplayCount { get; set; }
        public IList<RestaurantVM> Lists { get; set; }
    }
}
