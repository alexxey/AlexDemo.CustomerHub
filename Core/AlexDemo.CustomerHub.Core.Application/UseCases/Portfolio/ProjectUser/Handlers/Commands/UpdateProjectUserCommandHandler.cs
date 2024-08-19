using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Requests.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Handlers.Commands
{
    public class UpdateProjectUserCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        public Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
