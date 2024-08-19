using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice
{
    public record CreateCompanyOfficeDto
    {
        public required string Name { get; set; }

        public Country Country { get; set; }

        public string? ZipCode { get; set; }

        public int NumberOfEmployees { get; set; }

        public bool IsHeadOffice { get; set; }

        public int CompanyId { get; set; }
    }
}
