using Moq;
using SimpleCleanArchitecture.Application.Services.Email;

namespace SimpleCleanArchitecture.UnitTests.Services.Email
{
    public class EmailSenderHandlerTests
    {
        private EmailSenderHandler _handler;
        private Mock<IEmailSender> _emailSender;
        public EmailSenderHandlerTests()
        {
            _emailSender = new Mock<IEmailSender>();
            _handler = new EmailSenderHandler(_emailSender.Object);

        }

        [Fact]
        public async Task ThrowExceptionWithNullCommand()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(null, CancellationToken.None));
        }


        [Fact]
        public async Task SendEmailMethodShouldCallOnce()
        {
            await _handler.Handle(new EmailSenderCommand() { Body = It.IsAny<string>(), From = It.IsAny<string>(), Subject = It.IsAny<string>(), To = It.IsAny<string>() }, CancellationToken.None);
            _emailSender.Verify(sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }


    }
}
