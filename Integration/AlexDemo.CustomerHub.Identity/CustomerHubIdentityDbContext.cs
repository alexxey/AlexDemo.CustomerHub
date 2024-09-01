using AlexDemo.CustomerHub.Identity.Configurations;
using AlexDemo.CustomerHub.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlexDemo.CustomerHub.Identity
{
    public class CustomerHubIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CustomerHubIdentityDbContext(DbContextOptions<CustomerHubIdentityDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
