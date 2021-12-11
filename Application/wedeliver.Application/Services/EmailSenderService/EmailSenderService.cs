using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Configurations;
using wedeliver.Application.Services.Notification;

namespace wedeliver.Application.Services.EmailSenderService
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly ILogger _logger;

        public EmailSenderService(EmailConfiguration emailConfig, ILogger<EmailSenderService> logger)
        {
            _emailConfig = emailConfig;
            _logger = logger;
        }

       
        public async Task SendEmailAsync(NotificationMessage message)
        {
            var emailMessage = CreateEmailMessage(message);

            await Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(NotificationMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            return emailMessage;
        }

        private async Task Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    _logger.LogDebug("Started Sending E-mail...");
                    _logger.LogDebug(_emailConfig.SmtpServer, _emailConfig.UserName);

                     await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, _emailConfig.UseSsl);

                    if (!string.IsNullOrEmpty(_emailConfig.UserName) && !string.IsNullOrEmpty(_emailConfig.Password))
                        await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                    _logger.LogDebug("E-mail was sent.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    _logger.LogError(ex.StackTrace);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
