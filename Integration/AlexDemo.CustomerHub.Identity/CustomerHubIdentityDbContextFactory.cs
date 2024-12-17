using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AlexDemo.CustomerHub.Identity
{
    public class CustomerHubIdentityDbContextFactory : IDesignTimeDbContextFactory<CustomerHubIdentityDbContext>
    {
        public CustomerHubIdentityDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CustomerHubIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("CustomerHubIdentityConnectionString");

            // activate retry policy
            builder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());

            return new CustomerHubIdentityDbContext(builder.Options);
        }
    }
}
