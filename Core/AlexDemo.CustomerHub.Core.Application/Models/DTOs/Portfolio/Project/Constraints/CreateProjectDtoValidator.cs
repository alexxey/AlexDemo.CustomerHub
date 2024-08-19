using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project.Constraints
{
    public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(r => r.StartDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Project start time validation failed");
        }
    }
}
