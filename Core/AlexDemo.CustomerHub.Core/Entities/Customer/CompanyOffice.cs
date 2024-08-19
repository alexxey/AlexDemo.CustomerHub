using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Entities.Customer
{
    public sealed class CompanyOffice : BaseEntity
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string OfficeCode { get; set; }

        public Country Country { get; set; }

        public string? ZipCode { get; set; }

        public int NumberOfEmployees { get; set; }

        public bool IsHeadOffice { get; set; }

        public Company? Company { get; set; }

        public int CompanyId { get; set; }

        public List<User>? Users { get; set; } = [];

        public List<Project>? Projects { get; set; } = [];
    }
}
