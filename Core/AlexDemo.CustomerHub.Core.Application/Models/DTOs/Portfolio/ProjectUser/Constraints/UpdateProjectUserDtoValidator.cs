using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Common.Constraints;
using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser.Constraints
{
    public class UpdateProjectUserDtoValidator : AbstractValidator<UpdateProjectUserDto>
    {
        public UpdateProjectUserDtoValidator()
        {
            Include(new IUpdateBaseEntityValidator());
        }
    }
}
