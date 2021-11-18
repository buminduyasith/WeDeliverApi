using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.ViewModels
{
    public class UserVM
    {
        public string email { get; set; }
        public string Name { get; set; }
        public IList<string> UserRole { get; set; } = new List<string>();
        public string JwtKey { get; set; }
        public string UserIdentityId { get; set; }
        public int Id { get; set; }
    }
}
