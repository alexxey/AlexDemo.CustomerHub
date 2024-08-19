using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company
{
    public record UpdateCompanyDto : BaseDto<int>
    {
        public string? CeoName { get; set; }

        public string? Email { get; set; }

        public string? WebSite { get; set; }

        public Status Status { get; set; }

        public decimal Revenue { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
