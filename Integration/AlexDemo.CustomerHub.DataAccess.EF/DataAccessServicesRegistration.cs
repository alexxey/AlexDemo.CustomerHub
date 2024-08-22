using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Portfolio;
using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;
using AlexDemo.CustomerHub.DataAccess.EF.Repositories.Customer;
using AlexDemo.CustomerHub.DataAccess.EF.Repositories.Profile;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlexDemo.CustomerHub.DataAccess.EF
{
    public static class DataAccessServicesRegistration
    {
        public static IServiceCollection ConfigureDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerHubDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("CustomerHubConnection")));

            RegisterRepositories(services);

            return services;
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            // if base class is not abstract
            // services.AddScoped(typeof(IGenericRepository<, >), typeof(GenericRepository<, >));
            
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyOfficeRepository, CompanyOfficeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectUserRepository, ProjectUserRepository>();
        }
    }
}
