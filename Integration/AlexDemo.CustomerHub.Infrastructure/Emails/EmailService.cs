using AlexDemo.CustomerHub.Core.Application.Contracts.Infrastructure;
using AlexDemo.CustomerHub.Core.Application.Models.Emails;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AlexDemo.CustomerHub.Infrastructure.Emails
{
    public sealed class EmailService : IEmailService
    {
        private EmailSettings _emailSettings { get; }

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);

            var response = await client.SendEmailAsync(message);
            return response.StatusCode is System.Net.HttpStatusCode.OK or System.Net.HttpStatusCode.Accepted;
        }
    }
}
