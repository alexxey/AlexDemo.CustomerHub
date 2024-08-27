using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company
{
    public class UpdateCompanyVm: BaseVm<int>
    {
        public string? CeoName { get; set; }

        public string? Email { get; set; }

        public string? WebSite { get; set; }

        public decimal Revenue { get; set; }

        public int NumberOfEmployees { get; set; }

        public Status Status { get; set; }
    }
}
