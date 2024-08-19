using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Constraints;
using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User.Constraints
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        private readonly ICompanyOfficeRepository _companyOfficeRepository;
        public CreateUserDtoValidator(ICompanyOfficeRepository companyOfficeRepository)
        {
            // initialisation
            _companyOfficeRepository = companyOfficeRepository;

            // rule enforcements
            // date of birth
            RuleFor(r => r.DateOfBirth)
                .GreaterThanOrEqualTo(DateTime.UtcNow.AddYears(-EntityConstraints.Domain.UserSettings.MinAllowedAge))
                .WithMessage($"Person should be older than {EntityConstraints.Domain.UserSettings.MinAllowedAge} years old");

            // login
            RuleFor(r => r.Login)
                .NotEmpty().WithMessage("Login name is required")
                .MaximumLength(EntityConstraints.Domain.UserSettings.LoginLength)
                .WithMessage("Max length for login field is exceeded");

            // relationship checks
            // primary office Id
            RuleFor(r => r.PrimaryOfficeId)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value")
                .MustAsync(async (id, token) =>
                {
                    var companyOfficeExistsAndStillValid = await _companyOfficeRepository.CheckExistAndValid(id);
                    return !companyOfficeExistsAndStillValid;

                }).NotEmpty().WithMessage("{PropertyName} should be a valid reference");
        }
    }
}
