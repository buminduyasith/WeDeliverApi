using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.ViewModels
{
    public class ClientVM
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Location Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
