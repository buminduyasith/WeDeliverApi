using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Extensions
{
    public static class LocationExtension
    {
        public static string formattedLocation(this Location location)
        {
            return $"{location.HouseNo}";
        }
    }
}
