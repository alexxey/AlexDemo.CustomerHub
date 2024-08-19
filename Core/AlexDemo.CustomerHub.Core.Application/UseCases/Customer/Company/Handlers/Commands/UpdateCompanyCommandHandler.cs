using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Requests.Commands;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            // todo : add validation here
            if (request.UpdateDto is not {Id: > 0})
            {
                throw new ArgumentException(nameof(request));
            }

            var companyToUpdate = await _companyRepository.GetById(request.UpdateDto.Id);
            if (companyToUpdate.Status == Status.Deleted)
            {
                // throw Business Logic Exception : company no longer exists
                throw new ApplicationException("Company is not found");
            }

            _mapper.Map(request.UpdateDto, companyToUpdate);

            await _companyRepository.Update(companyToUpdate);

            return Unit.Value;
        }
    }
}
