using AlexDemo.CustomerHub.Core.Application.Models.Emails;

namespace AlexDemo.CustomerHub.Core.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
