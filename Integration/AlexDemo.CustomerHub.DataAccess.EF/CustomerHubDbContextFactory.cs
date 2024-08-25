using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AlexDemo.CustomerHub.DataAccess.EF;

public class CustomerHubDbContextFactory : IDesignTimeDbContextFactory<CustomerHubDbContext>
{
    public CustomerHubDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<CustomerHubDbContext>();
        var connectionString = configuration.GetConnectionString("CustomerHubConnection");
        
        // activate retry policy
        builder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
        
        return new CustomerHubDbContext(builder.Options);
    }
}