using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Portfolio;

using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser.Constraints
{
    public class CreateProjectUserDtoValidator : AbstractValidator<CreateProjectUserDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public CreateProjectUserDtoValidator(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            // initialisation
            _projectRepository = projectRepository;
            _userRepository = userRepository;

            // rule enforcement
            RuleFor(r => r.StartDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Project start time validation failed");

            // relationship checks
            // projectId
            RuleFor(r => r.ProjectId)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value")
            .MustAsync(async (id, token) =>
            {
                var projectExistsAndStillValid = await _projectRepository.CheckExistAndValid(id);
                return !projectExistsAndStillValid;

            }).NotEmpty().WithMessage("{PropertyName} should be a valid reference");

            // userId
            RuleFor(r => r.UserId)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value")
                .MustAsync(async (id, token) =>
                {
                    var userExistsAndValid = await _userRepository.CheckExistAndValid(id);
                    return !userExistsAndValid;

                }).NotEmpty().WithMessage("{PropertyName} should be a valid reference");
        }
    }
}
