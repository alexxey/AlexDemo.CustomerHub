using AlexDemo.CustomerHub.Core.Enums;
using FluentValidation;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Common.Constraints
{
    public class IUpdateBaseEntityValidator : AbstractValidator<IBaseStatusDto>
    {
        public IUpdateBaseEntityValidator()
        {
            RuleFor(r => r.Status)
                .NotEqual(Status.Deleted)
                .WithMessage("Deleted state is not supported in update flow");
        }
    }
}
