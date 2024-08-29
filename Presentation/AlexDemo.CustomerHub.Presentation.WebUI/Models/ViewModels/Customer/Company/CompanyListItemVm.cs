using System.ComponentModel.DataAnnotations;
using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.Core.Enums.Customer;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company
{
    public class CompanyListItemVm: BaseVm<int>
    {
        [Display(Name = "Brand")]
        public required string BrandName { get; set; }

        [Display(Name = "Head Office")]
        public Country HeadOfficeCountry { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Annual Revenue")]
        public decimal AnnualRevenue { get; set; }

        public Currency Currency { get; set; }

        [Display(Name = "Business Type")]
        public BusinessType BusinessType { get; set; }

        [Display(Name = "Number of employees")]
        public int NumberOfEmployees { get; set; }
    }
}
