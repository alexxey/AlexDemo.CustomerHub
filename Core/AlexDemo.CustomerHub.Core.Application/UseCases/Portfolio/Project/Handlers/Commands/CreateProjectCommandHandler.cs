using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Portfolio;
using AlexDemo.CustomerHub.Core.Application.Exceptions;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project.Constraints;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Handlers.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectDtoValidator = new CreateProjectDtoValidator();

            var validationResult = await projectDtoValidator.ValidateAsync(request.CreateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var project = _mapper.Map<Entities.Portfolio.Project>(request.CreateDto);

            project = await _projectRepository.Create(project);
            return project.Id;
        }
    }
}
