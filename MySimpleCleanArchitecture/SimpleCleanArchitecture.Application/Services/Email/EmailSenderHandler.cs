using MediatR;

namespace SimpleCleanArchitecture.Application.Services.Email
{
    public class EmailSenderHandler : INotificationHandler<EmailSenderCommand>
    {

        private readonly IEmailSender _emailSender;
        public EmailSenderHandler(IEmailSender emailSender)
        {

            _emailSender = emailSender;
        }

        public Task Handle(EmailSenderCommand notification, CancellationToken cancellationToken)
        {
            return _emailSender.SendEmailAsync(notification.To, notification.From, notification.Subject, notification.Body);
        }
    }
}
