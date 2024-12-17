using AlexDemo.CustomerHub.Core.Application.ServiceProviders;
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

            // alexdemo
            PasswordServiceProvider.CreatePasswordHash("admin-welcome", out var hash1, out var salt1);
            PasswordServiceProvider.CreatePasswordHash("employee-welcome", out var hash2, out var salt2);
            PasswordServiceProvider.CreatePasswordHash("visitor-welcome", out var hash3, out var salt3);

            // bentley
            PasswordServiceProvider.CreatePasswordHash("admin-welcome", out var hash4, out var salt4);
            PasswordServiceProvider.CreatePasswordHash("employee-welcome", out var hash5, out var salt5);

            // aston
            PasswordServiceProvider.CreatePasswordHash("admin-welcome", out var hash6, out var salt6);
            PasswordServiceProvider.CreatePasswordHash("employee-welcome", out var hash7, out var salt7);
            PasswordServiceProvider.CreatePasswordHash("employee-welcome", out var hash8, out var salt8);

            builder.HasData(
                new ApplicationUser
                {
                    Id = "B1228239-3B42-47F7-A9B7-22DEC0065942",
                    Email = "test-admin@customerhub.com",
                    NormalizedEmail = "TEST-ADMIN@CUSTOMERHUB.COM",
                    UserName = "test-admin",
                    NormalizedUserName = "TEST-ADMIN",
                    EmailConfirmed = true,
                    PasswordHash = Convert.ToBase64String(hash1),
                    PasswordSalt = Convert.ToBase64String(salt1)
                },
                new ApplicationUser
                {
                    Id = "76B6EF44-5415-4209-9163-55F6B7F50C42",
                    Email = "test-employee@customerhub.com",
                    NormalizedEmail = "TEST-EMPLOYEE@CUSTOMERHUB.COM",
                    UserName = "test-employee",
                    NormalizedUserName = "TEST-EMPLOYEE",
                    EmailConfirmed = true,
                    PasswordHash = Convert.ToBase64String(hash2),
                    PasswordSalt = Convert.ToBase64String(salt2)
                },
                new ApplicationUser
                {
                    Id = "6CC0E7C7-AA6D-4FAA-A055-E799C5F861A1",
                    Email = "test-visitor@customerhub.com",
                    NormalizedEmail = "TEST-VISITOR@CUSTOMERHUB.COM",
                    UserName = "test-visitor",
                    NormalizedUserName = "TEST-VISITOR",
                    EmailConfirmed = true,
                    PasswordHash = Convert.ToBase64String(hash3),
                    PasswordSalt = Convert.ToBase64String(salt3)
                },
                new ApplicationUser
                {
                    Id = "A3AD1AE6-A6A1-4317-B660-E29AB0BEC1BF",
                    Email = "test-admin@bentley.com",
                    NormalizedEmail = "TEST-ADMIN@BENTLEY.COM",
                    UserName = "test-admin",
                    NormalizedUserName = "TEST-ADMIN",
                    EmailConfirmed = true,
                    PasswordHash = Convert.ToBase64String(hash4),
                    PasswordSalt = Convert.ToBase64String(salt4)
                },
                new ApplicationUser
                {
                    Id = "832BE41E-7C11-43A0-9E03-DA328193C93E",
                    Email = "test-employee@bentley.com",
                    NormalizedEmail = "TEST-EMPLOYEE@BENTLEY.COM",
                    UserName = "test-employee",
                    NormalizedUserName = "TEST-EMPLOYEE",
                    EmailConfirmed = false,
                    PasswordHash = Convert.ToBase64String(hash5),
                    PasswordSalt = Convert.ToBase64String(salt5)
                },
                new ApplicationUser
                {
                    Id = "FB436184-620B-4549-8BC6-85494C026011",
                    Email = "test-Admin@aston.com",
                    NormalizedEmail = "TEST-ADMIN@ASTON.COM",
                    UserName = "test-admin",
                    NormalizedUserName = "TEST-ADMIN",
                    EmailConfirmed = true,
                    PasswordHash = Convert.ToBase64String(hash6),
                    PasswordSalt = Convert.ToBase64String(salt6)
                },
                new ApplicationUser
                {
                    Id = "1AA7B5AC-484E-4A2C-B6CB-D0F1286795D5",
                    Email = "test-employee@aston.com",
                    NormalizedEmail = "TEST-EMPLOYEE@ASTON.COM",
                    UserName = "test-employee",
                    NormalizedUserName = "TEST-EMPLOYEE",
                    EmailConfirmed = true,
                    PasswordHash = Convert.ToBase64String(hash7),
                    PasswordSalt = Convert.ToBase64String(salt7)
                },
                new ApplicationUser
                {
                    Id = "6150F338-7A79-439B-AC35-F20A4A6EA954",
                    Email = "test-employee1@aston.com",
                    NormalizedEmail = "TEST-EMPLOYEE1@ASTON.COM",
                    UserName = "test-employee1",
                    NormalizedUserName = "TEST-EMPLOYEE1",
                    EmailConfirmed = false,
                    PasswordHash = Convert.ToBase64String(hash8),
                    PasswordSalt = Convert.ToBase64String(salt8)
                }
            );
        }
    }
}
