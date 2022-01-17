using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Services.StandedMessage
{
    public interface ISendStandardMessageService
    {
        Task<bool> Send(StandardMessage standardMessage);
    }
}
