using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Services.Notification
{
    public interface INotificationDispatcherService
    {
        Task SendEmail(string templateTag,
           string[] toEmails,
           Dictionary<string, string> data,
           Dictionary<string, string> attachments = null);
    }
}
