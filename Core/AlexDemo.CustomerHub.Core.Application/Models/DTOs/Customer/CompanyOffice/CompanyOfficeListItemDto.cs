using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice
{
    public record CompanyOfficeListItemDto : BaseDto<int>
    {
        public required string Name { get; set; }

        public Country Country { get; set; }

        public int NumberOfEmployees { get; set; }

        public bool IsHeadOffice { get; set; }

        public int CompanyId { get; set; }

        public Status Status { get; set; }
    }
}
