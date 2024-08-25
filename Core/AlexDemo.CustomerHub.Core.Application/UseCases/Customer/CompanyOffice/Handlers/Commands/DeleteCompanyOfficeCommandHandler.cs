using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Commands;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Handlers.Commands
{
    public class DeleteCompanyOfficeCommandHandler : IRequestHandler<DeleteCompanyOfficeCommand, Unit>
    {
        private readonly ICompanyOfficeRepository _companyOfficeRepository;
        private readonly IMapper _mapper;

        public DeleteCompanyOfficeCommandHandler(ICompanyOfficeRepository companyOfficeRepository, IMapper mapper)
        {
            _companyOfficeRepository = companyOfficeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCompanyOfficeCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException(nameof(request.Id));
            }

            if (string.IsNullOrWhiteSpace(request.Actor))
            {
                throw new ArgumentException(nameof(request.Actor));
            }

            var companyOffice = await _companyOfficeRepository.GetById(request.Id);
            if (companyOffice.Status == Status.Deleted)
            {
                // there's no point to delete already deleted entity
                throw new ApplicationException("Entity already deleted");
            }

            await _companyOfficeRepository.Delete(companyOffice);

            return Unit.Value;
        }
    }
}
