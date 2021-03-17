using System;
using ImmortalFighters.WebApp.Models;
using ImmortalFighters.WebApp.Settings;
using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ImmortalFighters.WebApp.MediatR
{
    public class SendEmail : INotification
    {
        public MimeMessage Message { get; set; }
    }

    public class SendEmailHandler : INotificationHandler<SendEmail>
    {
        private readonly ILogger<SendEmailHandler> _logger;
        private readonly SmtpOptions _options;

        public SendEmailHandler(IOptions<SmtpOptions> options, ILogger<SendEmailHandler> logger)
        {
            _logger = logger;
            _options = options.Value;
        }

        public async Task Handle(SendEmail notification, CancellationToken cancellationToken)
        {
            try
            {
                using var client = new SmtpClient();

                var message = notification.Message;
                message.From.Add(new MailboxAddress(_options.SenderName, _options.SenderAddress));

                await client.ConnectAsync(_options.Server, _options.Port, true, cancellationToken);
                await client.AuthenticateAsync(_options.Username, _options.Password, cancellationToken);
                await client.SendAsync(notification.Message, cancellationToken);
                await client.DisconnectAsync(true, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Send email notification failed");
            }
        }
    }

    public class RegistrationEmailMessage
    {
        private readonly User user;

        public RegistrationEmailMessage(User user)
        {
            this.user = user;
        }

        public MimeMessage BuildMessage()
        {
            var message = new MimeMessage();

            var recipient = new MailboxAddress(user.Username, user.Email);
            message.To.Add(recipient);

            message.Subject = "Vítej do světa Immortal Fighters!";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "Pro dokončení registrace prosím klikni na tento <a href=\"\">odkaz</a>"; // TODO JG add correct url
            bodyBuilder.TextBody = "Pro dokončení registrace otevři tento odkaz: ";

            message.Body = bodyBuilder.ToMessageBody();

            return message;
        }
    }

}
