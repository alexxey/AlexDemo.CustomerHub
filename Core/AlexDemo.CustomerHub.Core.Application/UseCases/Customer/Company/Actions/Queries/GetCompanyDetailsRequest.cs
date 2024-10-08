﻿using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Queries
{
    public class GetCompanyDetailsRequest : IRequest<CompanyDetailsDto>
    {
        public int Id { get; set; }
    }
}
