using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.DataAccess.EF.Configurations.Entities.Customer
{
    internal class CompanyOfficeConfiguration : IEntityTypeConfiguration<CompanyOffice>
    {
        public void Configure(EntityTypeBuilder<CompanyOffice> modelBuilder)
        {
            int dynamicCompanyOfficeId = 1;

            var bentleyHeadOffice = new CompanyOffice
            {
                Id = dynamicCompanyOfficeId++,
                OfficeCode = "BNTL-1",
                CompanyId = 1, // bentleyCompany.Id,
                Country = Country.UnitedKingdom,
                NumberOfEmployees = 4000,
                IsHeadOffice = true,
                Name = "Bentley Motors Crewe",
                ZipCode = "CW1 3PL",
                UpdatedOn = DateTime.UtcNow
            };

            var astonMartinHeadOffice = new CompanyOffice
            {
                Id = dynamicCompanyOfficeId,
                OfficeCode = "ASTN-1",
                CompanyId = 2, //astonMartinCompany.Id,
                Country = Country.UnitedKingdom,
                NumberOfEmployees = 100,
                IsHeadOffice = true,
                Name = "Aston Martin Gaydon",
                ZipCode = "CV35 0DB",
                UpdatedOn = DateTime.UtcNow
            };

            modelBuilder.HasData(
                bentleyHeadOffice,
                astonMartinHeadOffice
            );
        }
    }
}
