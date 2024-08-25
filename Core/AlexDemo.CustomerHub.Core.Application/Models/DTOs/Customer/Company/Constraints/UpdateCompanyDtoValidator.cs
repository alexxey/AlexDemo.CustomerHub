using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Common.Constraints;
using AlexDemo.CustomerHub.Core.Constraints;
using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company.Constraints
{
    /// <summary>
    /// todo alex: complete me
    /// </summary>
    public class UpdateCompanyDtoValidator : AbstractValidator<UpdateCompanyDto>
    {
        public UpdateCompanyDtoValidator()
        {
            Include(new IUpdateBaseEntityValidator());
                
            // rules enforcement
            RuleFor(r => r.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value");
            
            RuleFor(r => r.CeoName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(EntityConstraints.CommonSettings.MediumStringLength);
        }
    }
}
