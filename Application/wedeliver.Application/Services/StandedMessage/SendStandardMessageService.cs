using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using wedeliver.Application.Configurations;

namespace wedeliver.Application.Services.StandedMessage
{
    public class SendStandardMessageService : ISendStandardMessageService
    {
        private readonly ILogger _logger;
        private readonly TwiloConfigurations _twiloConfigurations;

        public SendStandardMessageService(ILogger<SendStandardMessageService> logger, TwiloConfigurations twiloConfigurations)
        {
            _logger = logger;
            _twiloConfigurations = twiloConfigurations;
        }
        public async Task<bool> Send(StandardMessage standardMessage)
        {
            TwilioClient.Init(_twiloConfigurations.TWILIO_ACCOUNT_SID, _twiloConfigurations.TWILIO_AUTH_TOKEN);

            _logger.LogWarning($"config sid {_twiloConfigurations.TWILIO_ACCOUNT_SID} token { _twiloConfigurations.TWILIO_AUTH_TOKEN} ");

            var message =await MessageResource.CreateAsync(
            body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
            from: new Twilio.Types.PhoneNumber("+17652663556"),
            to: new Twilio.Types.PhoneNumber("+94778461152")
            );

            var status = message.Status;
            if(status == MessageResource.StatusEnum.Delivered)
            {
                _logger.LogInformation($"status Deliered");
            }

            _logger.LogWarning($"status {message.Status.ToString()}");
            Console.WriteLine(message.Sid);

            return true;

        }
    }
}
