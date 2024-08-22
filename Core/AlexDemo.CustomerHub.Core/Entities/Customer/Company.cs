using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.Core.Enums.Customer;

namespace AlexDemo.CustomerHub.Core.Entities.Customer
{
    public sealed class Company : BaseEntity
    {
        public int Id { get; set; }

        public required string BrandName { get; set; }

        public Country HeadOfficeCountry { get; set; }

        public required string CeoName { get; set; }

        public required string Email { get; set; }

        public string? WebSite { get; set; }

        public decimal Revenue { get; set; }

        public Currency Currency { get; set; }

        public BusinessType BusinessType { get; set; }

        public int NumberOfEmployees { get; set; }

        public List<CompanyOffice> Offices { get; set; } = [];

        public List<User> Users { get; set; } = [];

        public List<Project> Projects { get; set; } = [];
    }
}
