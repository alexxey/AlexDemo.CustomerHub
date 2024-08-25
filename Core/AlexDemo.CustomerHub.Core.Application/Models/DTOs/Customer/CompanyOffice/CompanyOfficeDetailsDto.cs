using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice
{
    public class CompanyOfficeDetailsDto : BaseDto<int>
    {
        public required string Name { get; set; }

        public required string OfficeCode { get; set; }

        public Country Country { get; set; }

        public string? ZipCode { get; set; }

        public int NumberOfEmployees { get; set; }

        public bool IsHeadOffice { get; set; }

        public int CompanyId { get; set; }

        public Status Status { get; set; }
    }
}
