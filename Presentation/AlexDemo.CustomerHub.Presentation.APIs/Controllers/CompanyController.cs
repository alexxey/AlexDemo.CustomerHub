using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;
using AlexDemo.CustomerHub.Core.Application.Responses;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Queries;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexDemo.CustomerHub.Presentation.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyListItemDto>>> Get()
        {
            var companies = await _mediator.Send(new GetCompaniesListRequest());

            return Ok(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetailsDto>> Get(int id)
        {
            var companyDetails = await _mediator.Send(new GetCompanyDetailsRequest
            {
                Id = id
            });

            return Ok(companyDetails);
        }

        // POST api/<CompanyController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CreateCompanyCommandResponse>> Post([FromBody] CreateCompanyDto createDto)
        {
            var command = new CreateCompanyCommand {CreateDto = createDto};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // todo alex: here I need to consider several approaches : should I use command of concrete type or generic one
        // concrete type should be useful in queues or other pipelines that can capture type specific commands, 
        // but the response can be generic entity as long as it contains all necessary information

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCompanyCommandResponse>> Put(int id, [FromBody] UpdateCompanyDto updateDto)
        {
            var command = new UpdateCompanyCommand { UpdateDto = updateDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCompanyCommandResponse>> Delete(int id)
        {
            var command = new DeleteCompanyCommand
            {
                Id = id,
                Actor = "test.user"
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
