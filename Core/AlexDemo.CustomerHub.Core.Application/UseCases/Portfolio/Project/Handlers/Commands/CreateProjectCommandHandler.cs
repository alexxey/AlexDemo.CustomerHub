using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
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
            if (request.CreateDto == null)
            {
                throw new ArgumentException("Command details are not provided");
            }

            var project = _mapper.Map<Entities.Portfolio.Project>(request.CreateDto);

            project = await _projectRepository.Create(project);
            return project.Id;
        }
    }
}
