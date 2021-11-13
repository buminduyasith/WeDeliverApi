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
        public string UserRole { get; set; }
        public string JwtKey { get; set; }
    }
}
