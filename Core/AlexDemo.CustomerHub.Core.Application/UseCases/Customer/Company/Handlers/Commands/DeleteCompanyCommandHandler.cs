using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteEntityCommand<int>, Unit>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEntityCommand<int> request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException(nameof(request.Id));
            }

            if (string.IsNullOrWhiteSpace(request.Actor))
            {
                throw new ArgumentException(nameof(request.Actor));
            }

            var company = await _companyRepository.GetById(request.Id);
            if (company.Status == Status.Deleted)
            {
                // there's no point to delete already deleted entity
                throw new ApplicationException("Entity already deleted");
            }

            await _companyRepository.Delete(company);

            return Unit.Value;
        }
    }
}
