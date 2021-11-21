using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;
using wedeliver.Domain.Enums;

namespace wedeliver.Domain.Entities
{
    public class Ratings: EntityBase
    {
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public virtual IdentityUser IdentityUser { get; set; }
 
        public Entity EntitieType { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public RatingType RatingType { get; set; }
        public string Comment { get; set; }
    }
}
