using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser.Constraints;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Handlers.Commands
{
    public class CreateProjectUserCommandHandler : IRequestHandler<CreateProjectUserCommand, long>
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateProjectUserCommandHandler(IProjectUserRepository projectUserRepository, IProjectRepository projectRepository, IUserRepository userRepository, IMapper mapper)
        {
            _projectUserRepository = projectUserRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateProjectUserCommand request, CancellationToken cancellationToken)
        {
            var projectUserValidator = new CreateProjectUserDtoValidator(_projectRepository, _userRepository);

            var validationResult = await projectUserValidator.ValidateAsync(request.CreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Command details are not valid");
            }

            var projectUser = _mapper.Map<Entities.Portfolio.ProjectUser>(request.CreateDto);

            projectUser = await _projectUserRepository.Create(projectUser);
            return projectUser.Id;
        }
    }
}
