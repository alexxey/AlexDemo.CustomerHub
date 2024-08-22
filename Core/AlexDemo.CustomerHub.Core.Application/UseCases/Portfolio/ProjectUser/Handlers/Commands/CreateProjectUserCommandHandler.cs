using AlexDemo.CustomerHub.Core.Application.Contracts.Infrastructure;
using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Portfolio;
using AlexDemo.CustomerHub.Core.Application.Exceptions;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser.Constraints;
using AlexDemo.CustomerHub.Core.Application.Models.Emails;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Handlers.Commands
{
    public class CreateProjectUserCommandHandler : IRequestHandler<CreateProjectUserCommand, long>
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailSender;

        public CreateProjectUserCommandHandler(IProjectUserRepository projectUserRepository, IProjectRepository projectRepository, IUserRepository userRepository, IMapper mapper, IEmailService emailSender)
        {
            _projectUserRepository = projectUserRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<long> Handle(CreateProjectUserCommand request, CancellationToken cancellationToken)
        {
            var projectUserValidator = new CreateProjectUserDtoValidator(_projectRepository, _userRepository);

            var validationResult = await projectUserValidator.ValidateAsync(request.CreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var projectUser = _mapper.Map<Entities.Portfolio.ProjectUser>(request.CreateDto);

            projectUser = await _projectUserRepository.Create(projectUser);

            try
            {
                // todo alex: extract into separate method
                var email = new Email
                {
                    To = "projectUser@email.me",
                    Subject = "New Project Assignment",
                    Body = "You have been assigned to the project ... as ... starting ... "
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                // todo alexx : log ex info, do not crash the flow
            }

            return projectUser.Id;
        }
    }
}
