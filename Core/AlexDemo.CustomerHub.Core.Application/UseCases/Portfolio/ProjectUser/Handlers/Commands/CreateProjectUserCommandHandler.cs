using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Requests.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Handlers.Commands
{
    public class CreateProjectUserCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IMapper _mapper;

        public CreateProjectUserCommandHandler(IProjectUserRepository projectUserRepository, IMapper mapper)
        {
            _projectUserRepository = projectUserRepository;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
