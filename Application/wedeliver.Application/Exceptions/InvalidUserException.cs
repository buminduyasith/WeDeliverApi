using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Exceptions
{
    public class InvalidUserException : ApplicationException
    {
        public InvalidUserException(string message)
            : base(message)
        {
        }
    }
}
