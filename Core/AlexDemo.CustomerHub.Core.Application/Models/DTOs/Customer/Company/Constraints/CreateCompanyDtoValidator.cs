using AlexDemo.CustomerHub.Core.Constraints;
using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company.Constraints
{
    public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto>
    {
        /// <summary>
        /// todo alex: complete me
        /// </summary>
        public CreateCompanyDtoValidator()
        {
            // alex validation tip1: validation hierarchy should be provided in order from the easiest validations to the most complicated ones in order to save server's resources

            RuleFor(r => r.BrandName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(EntityConstraints.Domain.CompanySettings.BrandNameLength); 

            RuleFor(r => r.NumberOfEmployees)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value");

            //todo: brand name as a unique constraint enforcement
        }
    }
}
