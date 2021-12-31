using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Services.Notification;

namespace wedeliver.Application.Services.EmailSenderServices
{
    public interface IEmailSenderService
    {

        Task SendEmailAsync(NotificationMessage message);
    }
}
