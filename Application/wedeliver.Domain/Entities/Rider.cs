using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class Rider: EntityBase
    {
        public string UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PersonalPhoneNumber { get; set; }
        private int LocationId { get; set; }
        public Location Location { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string DrivingLicenseUrl { get; set; }

    }
}
