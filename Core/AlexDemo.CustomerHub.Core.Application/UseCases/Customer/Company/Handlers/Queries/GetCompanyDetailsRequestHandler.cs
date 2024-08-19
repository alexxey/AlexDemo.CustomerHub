using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Queries
{
    public class GetCompanyDetailsRequestHandler : IRequestHandler<GetCompanyDetailsRequest, CompanyDetailsDto>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyDetailsRequestHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDetailsDto> Handle(GetCompanyDetailsRequest request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetById(request.Id);
            return _mapper.Map<CompanyDetailsDto>(company);
        }
    }
}
