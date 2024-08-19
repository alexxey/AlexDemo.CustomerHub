using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
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
                .MaximumLength(50);  // todo : refer to constants;

            RuleFor(r => r.CompanyId)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value")
                .MustAsync(async (id, token) =>
                {
                    var companyExistsAndStillValid = await _companyRepository.CheckExistAndValid(id);
                    return !companyExistsAndStillValid;

                }).NotEmpty().WithMessage("{PropertyName} should be a valid reference");

        }
    }
}
