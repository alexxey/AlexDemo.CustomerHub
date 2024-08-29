using System.ComponentModel.DataAnnotations;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company
{
    public class CreateCompanyVm
    {
        [Display(Name = "Brand")]
        [Required]
        public required string BrandName { get; set; }

        [Display(Name = "Head Office")]
        [Required]
        public Country HeadOfficeCountry { get; set; }

        [Display(Name="Number of employees")]
        public int NumberOfEmployees { get; set; }

        [Display(Name = "Annual Revenue")]
        public decimal AnnualRevenue { get; set; }
    }
}
