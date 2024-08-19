using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User
{
    public record UserListItemDto : BaseDto<int>
    {
        public string? FullName { get; set; }

        public EmployeeCompanyRole CompanyRole { get; set; }

        public required string Email { get; set; }

        public int PrimaryOfficeId { get; set; }

        public Status Status { get; set; }
    }
}
