using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Queries
{
    public class GetCompaniesListRequestHandler : IRequestHandler<GetCompaniesListRequest, List<CompanyListItemDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompaniesListRequestHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository  = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyListItemDto>> Handle(GetCompaniesListRequest request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAll();
            return _mapper.Map<List<CompanyListItemDto>>(companies);
        }
    }
}
