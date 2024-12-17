using AlexDemo.CustomerHub.Core.Entities.Customer;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.DataAccess.EF.Configurations.Entities.Customer
{
    internal class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> modelBuilder)
        {
            int dynamicUserId = 1;
            int alexDemoHeadOfficeId = 1;
            int bentleyHeadOfficeId = 2;
            int astonHeadOfficeId = 3;

            int alexDemoCompanyId = 1;
            int bentleyCompanyId = 3;
            int astonMartinCompanyId = 1;

            // seed data for users table 
            var testAlexDemoAdmin = GetUserInfo(dynamicUserId++, "B1228239-3B42-47F7-A9B7-22DEC0065942", new DateTime(1981, 12, 22), "admin.alexDemo", bentleyHeadOfficeId, alexDemoCompanyId, "Test", "Sir", "Mr", "admin.alexdemo@customerhub.com");
            var testAlexDemoEmployee = GetUserInfo(dynamicUserId++, "76B6EF44-5415-4209-9163-55F6B7F50C42", new DateTime(1988, 04, 22), "employee.alexDemo", bentleyHeadOfficeId, alexDemoCompanyId, "Test", "Sir", "Mr", "employee.alexdemo@customerhub.com");
            var testAlexDemoVisitor = GetUserInfo(dynamicUserId++, "6CC0E7C7-AA6D-4FAA-A055-E799C5F861A1", new DateTime(2001, 01, 01), "visitor.alexDemo", bentleyHeadOfficeId, alexDemoCompanyId, "Test", "Sir", "Mr", "visitor.alexdemo@customerhub.com");

            var testBentleyAdmin = GetUserInfo(dynamicUserId++, "A3AD1AE6-A6A1-4317-B660-E29AB0BEC1BF", new DateTime(1961, 01, 17), "admin.bentley", bentleyHeadOfficeId, bentleyCompanyId, "Test", "Sir", "Mr", "admin.bentley@bentley.com");
            var testBentleyEmployee = GetUserInfo(dynamicUserId++, "832BE41E-7C11-43A0-9E03-DA328193C93E", new DateTime(1993, 10, 02), "employee.bentley", bentleyHeadOfficeId, bentleyCompanyId, "Test", "Sir", "Mr", "employee.bentley@bentley.com");

            var testAstonMartinAdmin = GetUserInfo(dynamicUserId++, "FB436184-620B-4549-8BC6-85494C026011", new DateTime(1983, 6, 11), "admin.aston", astonHeadOfficeId, astonMartinCompanyId,"Test", "Madam", "Mrs","admin.aston@aston.com");
            var testAstonEmployee1 = GetUserInfo(dynamicUserId, "1AA7B5AC-484E-4A2C-B6CB-D0F1286795D5", new DateTime(1999, 2, 20), "employee.aston", bentleyHeadOfficeId, astonMartinCompanyId, null, null, null, "test-employee@aston.com");
            var testAstonEmployee2 = GetUserInfo(dynamicUserId, "6150F338-7A79-439B-AC35-F20A4A6EA954", new DateTime(1999, 8, 02), "user.aston", bentleyHeadOfficeId, astonMartinCompanyId, null, null, null, "test-user@aston.com");

            modelBuilder.HasData(
                testAlexDemoAdmin,
                testAlexDemoEmployee,
                testAlexDemoVisitor,
                testBentleyAdmin,
                testBentleyEmployee,
                testAstonMartinAdmin,
                testAstonEmployee1,
                testAstonEmployee2
            );
        }

        private static CompanyUser GetUserInfo(
            int id,
            string identityUserId,
            DateTime dateOfBirth,
            string displayName,
            int officeId,
            int companyId,
            string firstName,
            string lastName,
            string title,
            string email)
        {
            // seed data for users table 
            var userEntity = new CompanyUser
            {
                Id = id,
                IdentityUserId = identityUserId,
                DateOfBirth = dateOfBirth,
                DisplayName = displayName,
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
