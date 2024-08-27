using System.ComponentModel.DataAnnotations;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company
{
    public class CreateCompanyVm
    {
        [Required]
        public required string BrandName { get; set; }

        [Required]
        public Country HeadOfficeCountry { get; set; }

        [Required]
        [Display(Name="Number of employees")]
        public int NumberOfEmployees { get; set; }
    }
}
