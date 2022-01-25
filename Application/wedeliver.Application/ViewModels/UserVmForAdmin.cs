using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.ViewModels
{
    public class UserVmForAdmin
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SignupDate { get; set; }
    }
}
