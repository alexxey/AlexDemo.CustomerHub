using AlexDemo.CustomerHub.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.Identity.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "B1228239-3B42-47F7-A9B7-22DEC0065942",
                    Email = "test-admin@customerhub.com",
                    NormalizedEmail = "TEST-ADMIN@CUSTOMERHUB.COM",
                    FirstName = "System",
                    LastName = "Administrator",
                    UserName = "test-admin",
                    NormalizedUserName = "TEST-ADMIN",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Welcome1"),
                    CompanyId = 1
                },
                new ApplicationUser
                {
                    Id = "832BE41E-7C11-43A0-9E03-DA328193C93E",
                    Email = "test-employee@customerhub.com",
                    NormalizedEmail = "TEST-EMPLOYEE@CUSTOMERHUB.COM",
                    FirstName = "Test",
                    LastName = "Employee",
                    UserName = "test-employee",
                    NormalizedUserName = "TEST-EMPLOYEE",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Welcome2"),
                    CompanyId = 1
                },
                new ApplicationUser
                {
                    Id = "FB436184-620B-4549-8BC6-85494C026011",
                    Email = "test-visitor@customerhub.com",
                    NormalizedEmail = "TEST-VISITOR@CUSTOMERHUB.COM",
                    FirstName = "Test",
                    LastName = "Visitor",
                    UserName = "test-visitor",
                    NormalizedUserName = "TEST-VISITOR",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Welcome3"),
                    CompanyId = 1
                }
            );
        }
    }
}
