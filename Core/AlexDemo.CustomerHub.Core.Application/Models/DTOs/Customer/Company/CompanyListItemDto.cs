﻿using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.Core.Enums.Customer;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company
{
    public record CompanyListItemDto : BaseDto<int>
    {
        public required string BrandName { get; set; }

        public Country HeadOfficeCountry { get; set; }

        public Status Status { get; set; }

        public decimal Revenue { get; set; }

        public Currency Currency { get; set; }

        public BusinessType BusinessType { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
