using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.Core.Enums.Customer;

namespace AlexDemo.CustomerHub.Core.Application.ServiceProviders
{
    internal static class CompanyMetadataServiceProvider
    {
        public static BusinessType DefineBusinessTypeModel(Company company)
        {
            if (company.NumberOfEmployees <= 1 || company.AnnualRevenue <= 1)
            {
                return BusinessType.NotSpecified;
            }

            // todo alex : simple logic to calculate company's business type based on some simple scenario
            if (company.NumberOfEmployees <= 50)
            {
                return BusinessType.SmallEnterprise;
            }

            if (company.NumberOfEmployees <= 250)
            {
                return BusinessType.MidSizeEnterprise;
            }

            if (company.NumberOfEmployees <= 1000)
            {
                return BusinessType.LargeEnterprise;
            }

            if (company.NumberOfEmployees <= 10000)
            {
                return BusinessType.MajorAutomotiveManufacturer;
            }

            if (company.NumberOfEmployees <= 100000)
            {
                return BusinessType.GlobalAutomotiveGiant;
            }

            return BusinessType.GlobalConglomerate;
        }

        public static Currency DefineCurrency(Country country)
        {
            // todo alex : simple logic to determine currency for the entity based on country info
            if (country == Country.Japan)
            {
                return Currency.JPY;
            }

            if (country == Country.USA)
            {
                return Currency.USD;
            }

            if (country == Country.UnitedKingdom)
            {
                return Currency.GBP;
            }

            if (country == Country.CzechRepublic || country == Country.Germany || country == Country.Sweden)
            {
                return Currency.EURO;
            }

            return Currency.NotDefined;
        }
    }
}
