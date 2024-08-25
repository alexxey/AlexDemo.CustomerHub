using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice
{
    public class UpdateCompanyOfficeDto : BaseDto<int>, IBaseStatusDto
    {
        public string? Name { get; set; }

        public Country Country { get; set; }

        public string? ZipCode { get; set; }

        public int NumberOfEmployees { get; set; }

        public bool IsHeadOffice { get; set; }

        public Status Status { get; set; }
    }
}
