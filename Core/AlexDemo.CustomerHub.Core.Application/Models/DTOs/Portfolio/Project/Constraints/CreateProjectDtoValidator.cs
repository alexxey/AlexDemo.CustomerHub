using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
