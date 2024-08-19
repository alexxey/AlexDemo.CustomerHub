using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Handlers.Queries
{
    public class GetCompanyOfficesListRequestHandler : IRequestHandler<GetCompanyOfficesListRequest, List<CompanyOfficeListItemDto>>
    {
        private readonly ICompanyOfficeRepository _companyOfficeRepository;
        private readonly IMapper _mapper;

        public GetCompanyOfficesListRequestHandler(ICompanyOfficeRepository companyOfficeRepository, IMapper mapper)
        {
            _companyOfficeRepository = companyOfficeRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyOfficeListItemDto>> Handle(GetCompanyOfficesListRequest request, CancellationToken cancellationToken)
        {
            // todo : param validation
            if (request.CompanyId <= 0)
            {
                throw new NotSupportedException("List without company is not supported");
            }

            var companyOffices = await _companyOfficeRepository.GetAllByCompany(request.CompanyId);
            return _mapper.Map<List<CompanyOfficeListItemDto>>(companyOffices);
        }
    }
}
