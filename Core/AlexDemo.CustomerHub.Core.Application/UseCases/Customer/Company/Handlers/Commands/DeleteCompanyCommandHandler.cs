using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Enums;
using AlexDemo.CustomerHub.Core.Application.Responses;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Responses;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, DeleteCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<DeleteCompanyCommandResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentException(nameof(request.Id));
            }

            if (string.IsNullOrWhiteSpace(request.Actor))
            {
                throw new ArgumentException(nameof(request.Actor));
            }

            var response = new DeleteCompanyCommandResponse
            {
                Id = request.Id
            };


            var company = await _companyRepository.GetById(request.Id);
            if (company == null || company.Status == Status.Deleted)
            {
                // an alternative approach not to throw exceptions but to work with response types
                response.IsSuccessful = false;
                response.Message = "Delete Company Failed";
                response.Data =
                [
                    new ResponseMessageModel
                    {
                        ResponseType = ResponseType.ValidationError,
                        Message = "already deleted"
                    }

                ];

                return response;
            }

            await _companyRepository.DeleteById(company.Id);

            response.IsSuccessful = true;
            response.Message = "Company deleted";
            return response;
        }
    }
}
