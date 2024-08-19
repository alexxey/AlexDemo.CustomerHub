using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Constraints;

using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice.Constraints
{
    public class CreateCompanyOfficeDtoValidator : AbstractValidator<CreateCompanyOfficeDto>
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyOfficeDtoValidator(ICompanyRepository companyRepository)
        {
            // initialisation
            _companyRepository = companyRepository;

            // rules enforcement
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(EntityConstraints.Domain.CompanyOfficeSettings.OfficeNameLength);

            // relationship checks
            RuleFor(r => r.CompanyId)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value")
                .MustAsync(async (id, token) =>
                {
                    var companyExistsAndStillValid = await _companyRepository.CheckExistAndValid(id);
                    return !companyExistsAndStillValid;

                }).NotEmpty().WithMessage("{PropertyName} should be a valid reference");

            // todo : load list of offices for the company to check name constraints
        }
    }
}
