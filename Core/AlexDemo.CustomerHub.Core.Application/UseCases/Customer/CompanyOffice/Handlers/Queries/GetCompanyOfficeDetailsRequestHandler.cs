using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Handlers.Queries
{
    public class GetCompanyOfficeDetailsRequestHandler : IRequestHandler<GetCompanyOfficeDetailsRequest, CompanyOfficeDetailsDto>
    {
        private readonly ICompanyOfficeRepository _companyOfficeRepository;
        private readonly IMapper _mapper;

        public GetCompanyOfficeDetailsRequestHandler(ICompanyOfficeRepository companyOfficeRepository, IMapper mapper)
        {
            _companyOfficeRepository = companyOfficeRepository;
            _mapper = mapper;
        }

        public async Task<CompanyOfficeDetailsDto> Handle(GetCompanyOfficeDetailsRequest request, CancellationToken cancellationToken)
        {
            var companyOffice = await _companyOfficeRepository.GetById(request.Id);
            return _mapper.Map<CompanyOfficeDetailsDto>(companyOffice);
        }
    }
}
