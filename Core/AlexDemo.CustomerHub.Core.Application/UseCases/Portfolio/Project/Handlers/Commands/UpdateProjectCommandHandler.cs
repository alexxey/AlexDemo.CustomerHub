using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Portfolio;
using AlexDemo.CustomerHub.Core.Application.Exceptions;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project.Constraints;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Commands;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Handlers.Commands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var updateProjectValidator = new UpdateProjectDtoValidator();
            var validationResult = await updateProjectValidator.ValidateAsync(request.UpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                 throw new Exceptions.ValidationException(validationResult);
            }

            var projectToUpdate = await _projectRepository.GetById(request.UpdateDto.Id);
            if (projectToUpdate.Status == Status.Deleted)
            {
                throw new NotFoundException(nameof(Project), request.UpdateDto.Id);
            }

            _mapper.Map(request.UpdateDto, projectToUpdate);

            await _projectRepository.Update(projectToUpdate);

            return Unit.Value;
        }
    }
}
