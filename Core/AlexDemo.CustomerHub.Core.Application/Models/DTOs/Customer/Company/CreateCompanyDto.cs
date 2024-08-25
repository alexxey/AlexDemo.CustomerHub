using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company
{
    public class CreateCompanyDto
    {
        public required string BrandName { get; set; }

        public Country HeadOfficeCountry { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
