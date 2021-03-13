using ImmortalFighters.WebApp.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.MediatR
{
    public class SendEmail : INotification
    {
    }

    public class SendEmailHandler : INotificationHandler<SendEmail>
    {
        private readonly SmtpOptions options;

        public SendEmailHandler(IOptions<SmtpOptions> smtpOptions)
        {
            options = smtpOptions.Value;
        }

        public Task Handle(SendEmail notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
