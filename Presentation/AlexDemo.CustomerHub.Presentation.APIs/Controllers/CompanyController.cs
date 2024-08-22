using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Queries;
using MediatR;

using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<ActionResult> Post([FromBody] CreateCompanyDto createDto)
        {
            var command = new CreateCompanyCommand {CreateDto = createDto};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateCompanyDto updateDto)
        {
            var command = new UpdateCompanyCommand { UpdateDto = updateDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCompanyCommand
            {
                Id = id,
                Actor = "test.user"
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
