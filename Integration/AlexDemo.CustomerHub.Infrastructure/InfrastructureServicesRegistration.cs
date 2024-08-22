using AlexDemo.CustomerHub.Core.Application.Contracts.Infrastructure;
using AlexDemo.CustomerHub.Core.Application.Models.Emails;
using AlexDemo.CustomerHub.Infrastructure.Emails;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlexDemo.CustomerHub.Infrastructure
{
    public static class InfrastructureServicesRegistration 
    {
        public static IServiceCollection ConfigureDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
