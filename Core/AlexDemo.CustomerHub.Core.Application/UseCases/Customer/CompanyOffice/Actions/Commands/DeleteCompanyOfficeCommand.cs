﻿using AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Commands
{
    public record DeleteCompanyOfficeCommand : DeleteEntityCommand<int>
    {
    }
}
