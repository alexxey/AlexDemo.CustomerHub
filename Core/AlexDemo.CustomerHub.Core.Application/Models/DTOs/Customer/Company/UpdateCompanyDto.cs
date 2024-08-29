using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company
{
    public class UpdateCompanyDto : BaseDto<int>, IBaseStatusDto
    {
        public string? CeoName { get; set; }

        public string? Email { get; set; }

        public string? WebSite { get; set; }

        public decimal AnnualRevenue { get; set; }

        public int NumberOfEmployees { get; set; }

        public Status Status { get; set; }
    }
}
