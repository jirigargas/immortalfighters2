using ImmortalFighters.WebApp.Models;
using ImmortalFighters.WebApp.Settings;
using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.MediatR
{
    public class SendEmail : INotification
    {
        public MimeMessage Message { get; set; }
    }

    public class SendEmailHandler : INotificationHandler<SendEmail>
    {
        private readonly SmtpOptions options;

        public SendEmailHandler(IOptions<SmtpOptions> smtpOptions)
        {
            options = smtpOptions.Value;
        }

        public async Task Handle(SendEmail notification, CancellationToken cancellationToken)
        {
            using var client = new SmtpClient();

            var message = notification.Message;
            message.From.Add(new MailboxAddress(options.SenderName, options.SenderAddress));

            await client.ConnectAsync(options.Server, options.Port, true, cancellationToken);
            await client.AuthenticateAsync(options.Username, options.Password, cancellationToken);
            await client.SendAsync(notification.Message);
            await client.DisconnectAsync(true);
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
