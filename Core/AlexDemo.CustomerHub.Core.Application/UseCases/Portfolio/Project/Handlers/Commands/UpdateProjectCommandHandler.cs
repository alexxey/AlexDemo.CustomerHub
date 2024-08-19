using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
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
            if (request.UpdateDto is not {Id: > 0})
            {
                throw new ArgumentException(nameof(request));
            }

            var projectToUpdate = await _projectRepository.GetById(request.UpdateDto.Id);
            if (projectToUpdate.Status == Status.Deleted)
            {
                // throw Business Logic Exception : company no longer exists
                throw new ApplicationException("Project is not found");
            }

            _mapper.Map(request.UpdateDto, projectToUpdate);

            await _projectRepository.Update(projectToUpdate);

            return Unit.Value;
        }
    }
}
