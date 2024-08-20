using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Common.Constraints;

using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project.Constraints
{
    public class UpdateProjectDtoValidator : AbstractValidator<UpdateProjectDto>
    {
        public UpdateProjectDtoValidator()
        {
            Include(new IUpdateBaseEntityValidator());
        }
    }
}
