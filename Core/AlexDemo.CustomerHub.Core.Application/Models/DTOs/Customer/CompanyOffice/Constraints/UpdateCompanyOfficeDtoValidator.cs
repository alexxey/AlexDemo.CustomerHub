using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Common.Constraints;
using AlexDemo.CustomerHub.Core.Enums;
using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice.Constraints
{
    internal class UpdateCompanyOfficeDtoValidator : AbstractValidator<UpdateCompanyOfficeDto>
    {
        /// <summary>
        ///  todo alex: complete me
        /// </summary>
        public UpdateCompanyOfficeDtoValidator()
        {
            Include(new IUpdateBaseEntityValidator());

            // rules enforcement
            RuleFor(r => r.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value");
        }
    }
}

