using AlexDemo.CustomerHub.Core.Application.Exceptions;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser.Constraints;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Actions.Commands;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Handlers.Commands
{
    public class UpdateProjectUserCommandHandler : IRequestHandler<UpdateProjectUserCommand, Unit>
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateProjectUserCommandHandler(IProjectUserRepository projectUserRepository, IProjectRepository projectRepository, IUserRepository userRepository, IMapper mapper)
        {
            _projectUserRepository = projectUserRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProjectUserCommand request, CancellationToken cancellationToken)
        {
            var updateProjectUserValidator = new UpdateProjectUserDtoValidator();
            var validationResult = await updateProjectUserValidator.ValidateAsync(request.UpdateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var projectUserToUpdate = await _projectUserRepository.GetById(request.UpdateDto.Id);
            if (projectUserToUpdate.Status == Status.Deleted)
            {
                throw new NotFoundException(nameof(ProjectUser), request.UpdateDto.Id);
            }

            _mapper.Map(request.UpdateDto, projectUserToUpdate);
            await _projectUserRepository.Update(projectUserToUpdate);

            return Unit.Value;
        }
    }
}
