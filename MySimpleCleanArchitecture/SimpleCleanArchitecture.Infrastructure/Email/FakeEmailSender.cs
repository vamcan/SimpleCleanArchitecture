using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCleanArchitecture.Application.Services.Email;

namespace SimpleCleanArchitecture.Infrastructure.Email
{
    public class FakeEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string to, string from, string subject, string body)
        {
            Console.WriteLine($"Email Sent To: {to}");
            return Task.CompletedTask;
        }
    }
}
