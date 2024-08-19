using System.Data;
using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company.Constraints
{
    public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto>
    {
        public CreateCompanyDtoValidator()
        {
            // alex validation tip1: validation hierarchy should be provided in order from the easiest validations to the most complicated ones in order to save server's resources

            RuleFor(r => r.BrandName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50);  // todo : refer to constants;

            RuleFor(r => r.NumberOfEmployees)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value");
        }
    }
}
