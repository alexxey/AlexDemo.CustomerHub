using System.ComponentModel.DataAnnotations;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company
{
    public class UpdateCompanyVm: BaseVm<int>
    {
        [Display(Name = "Ceo")]
        public string? CeoName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Url]
        public string? WebSite { get; set; }

        [Display(Name = "Annual Revenue")]
        public decimal AnnualRevenue { get; set; }

        [Display(Name = "Number of employees")]
        public int NumberOfEmployees { get; set; }

        public Status Status { get; set; }
    }
}
