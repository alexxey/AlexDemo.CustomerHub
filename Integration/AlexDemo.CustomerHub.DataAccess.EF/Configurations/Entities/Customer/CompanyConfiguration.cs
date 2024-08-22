using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Enums.Customer;

using AlexDemo.CustomerHub.Core.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.DataAccess.EF.Configurations.Entities.Customer
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company> 
    {
        public void Configure(EntityTypeBuilder<Company> modelBuilder)
        {
            int dynamicCompanyId = 1;

            var bentleyCompany = new Company
            {
                Id = dynamicCompanyId,
                BrandName = "Bentley",
                Email = "bentley@demo.com",
                Status = Status.Active,
                UpdatedOn = DateTime.UtcNow.AddMinutes(-1),
                HeadOfficeCountry = Country.UnitedKingdom,
                CeoName = "Adrian Hallmark",
                Currency = Currency.GBP,
                BusinessType = BusinessType.LargeEnterprise,
                NumberOfEmployees = 5000,
                Revenue = 3700000,
                WebSite = "www.bentleymotors.com"
            };

            var astonMartinCompany = new Company
            {
                Id = ++dynamicCompanyId,
                BrandName = "Aston Martin",
                Email = "aston-martin@demo.com",
                Status = Status.Active,
                UpdatedOn = DateTime.UtcNow,
                HeadOfficeCountry = Country.UnitedKingdom,
                CeoName = "Amedeo Felisa",
                Currency = Currency.GBP,
                BusinessType = BusinessType.LargeEnterprise,
                NumberOfEmployees = 2500,
                Revenue = 1400000000,
                WebSite = "www.astonmartin.com"
            };

            // Seed data for the Customers table
            modelBuilder.HasData(
                bentleyCompany,
                astonMartinCompany,
                new Company { Id = ++dynamicCompanyId, BrandName = "BMW", Email = "bnw@demo.com", Status = Status.Draft, UpdatedOn = DateTime.UtcNow, HeadOfficeCountry = Country.Germany, CeoName = "Oliver Zipse", Currency = Currency.EURO, BusinessType = BusinessType.GlobalConglomerate, NumberOfEmployees = 130000, Revenue = 158000000000 },
                new Company { Id = ++dynamicCompanyId, BrandName = "Volvo", Email = "volvo@demo.com", Status = Status.Active, UpdatedOn = DateTime.UtcNow.AddDays(-6), HeadOfficeCountry = Country.Sweden, CeoName = "Jim Rowan", Currency = Currency.EURO, BusinessType = BusinessType.MajorAutomotiveManufacturer, NumberOfEmployees = 40000, Revenue = 36200000000 },
                new Company { Id = ++dynamicCompanyId, BrandName = "Toyota", Email = "toyota@demo.com", Status = Status.Disabled, UpdatedOn = DateTime.UtcNow, HeadOfficeCountry = Country.Japan, CeoName = "Akio Toyoda", Currency = Currency.JPY, BusinessType = BusinessType.GlobalConglomerate, NumberOfEmployees = 370000, Revenue = 240000000000 },
                new Company { Id = ++dynamicCompanyId, BrandName = "Audi", Email = "audi@demo.com", Status = Status.Active, UpdatedOn = DateTime.UtcNow, HeadOfficeCountry = Country.Germany, CeoName = "Markus Duesmann", Currency = Currency.EURO, BusinessType = BusinessType.GlobalAutomotiveGiant, NumberOfEmployees = 90000, Revenue = 61400000000 },
                new Company { Id = ++dynamicCompanyId, BrandName = "Ford", Email = "ford@demo.com", Status = Status.Active, UpdatedOn = DateTime.UtcNow, HeadOfficeCountry = Country.USA, CeoName = "Jim Farley", Currency = Currency.USD, BusinessType = BusinessType.GlobalConglomerate, NumberOfEmployees = 180000, Revenue = 167000000000 },
                new Company { Id = ++dynamicCompanyId, BrandName = "Skoda", Email = "skoda@demo.com", Status = Status.Draft, UpdatedOn = DateTime.UtcNow, HeadOfficeCountry = Country.CzechRepublic, CeoName = "Klaus Zellmer", Currency = Currency.EURO, BusinessType = BusinessType.MajorAutomotiveManufacturer, NumberOfEmployees = 45000, Revenue = 23000000000 }
            );
        }
    }
}
