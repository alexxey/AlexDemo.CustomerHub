using AlexDemo.CustomerHub.Core.Application.Enums;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company.Constraints;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.Responses;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Responses;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCompanyCommandResponse();

            var companyValidator = new CreateCompanyDtoValidator();
            var validationResult = await companyValidator.ValidateAsync(request.CreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                // an alternative approach not to throw expcetions but to work with response types
                response.IsSuccessful = false;
                response.Message = "Create Company Failed";
                response.Data = new List<ResponseMessageModel>();
                foreach (var validationResultError in validationResult.Errors)
                {
                    response.Data.Add(new ResponseMessageModel
                    {
                        ResponseType = ResponseType.ValidationError, Message = validationResultError.ErrorMessage
                    });
                }
            }
            
            var company = _mapper.Map<Entities.Customer.Company>(request.CreateDto);

            company = await _companyRepository.Create(company);

            response.IsSuccessful = true;
            response.Id = company.Id;
            response.Message = "Company created";
            return response;
        }
    }
}
