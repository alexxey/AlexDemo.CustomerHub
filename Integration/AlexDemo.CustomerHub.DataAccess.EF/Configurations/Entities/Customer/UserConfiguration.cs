using AlexDemo.CustomerHub.Core.Application.ServiceProviders;
using AlexDemo.CustomerHub.Core.Entities.Customer;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.DataAccess.EF.Configurations.Entities.Customer
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            int dynamicUserId = 1;
            int bentleyHeadOfficeId = 1;
            int astonHeadOfficeId = 2;

            int bentleyCompanyId = 1;
            int astonMartinCompanyId = 2;

            // seed data for users table 
            var testBentleyUser = GetUserInfo(dynamicUserId++, new DateTime(1981, 12, 22), "test.bentley", "tbentley", bentleyHeadOfficeId, bentleyCompanyId, "Test", "Sir", "Mr", "test.bentley@bentley.com");
            var testAstonMartinUser = GetUserInfo(dynamicUserId++, new DateTime(1983, 6, 11), "test.aston", "taston", astonHeadOfficeId, astonMartinCompanyId,"Test", "Madam", "Mrs", "test.aston@aston.com");
            var testBentleyUser2 = GetUserInfo(dynamicUserId, new DateTime(1999, 2, 20), "user.benntley", "bentley2", bentleyHeadOfficeId, bentleyCompanyId, null, null, null, "user.bentley@aston.com");

            modelBuilder.HasData(
                testBentleyUser,
                testAstonMartinUser,
                testBentleyUser2
            );
        }

        private static User GetUserInfo(
            int id,
            DateTime dateOfBirth,
            string login,
            string password,
            int officeId,
            int companyId,
            string firstName,
            string lastName,
            string title,
            string email)
        {
            PasswordServiceProvider.CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            // seed data for users table 
            var userEntity = new User
            {
                Id = id,
                DateOfBirth = dateOfBirth,
                Login = login,
                PasswordHash = Convert.ToBase64String(hash),
                PasswordSalt = Convert.ToBase64String(salt),
                PrimaryOfficeId = officeId,
                CompanyId = companyId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Title = title,
                UpdatedOn = DateTime.UtcNow
            };

            return userEntity;
        }
    }
}
