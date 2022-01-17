using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface ICurrentUserService
    {
        string IdentityId { get; }

        string Name { get; }

        string UserEmail { get; }

        string Id { get; }

        string Role { get; }

      
    }
}
