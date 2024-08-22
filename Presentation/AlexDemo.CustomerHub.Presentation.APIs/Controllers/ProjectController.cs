using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Queries;
using MediatR;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexDemo.CustomerHub.Presentation.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectListItemDto>>> Get()
        {
            // add here companyId or companyOfficeId
            var projects = await _mediator.Send(new GetProjectsListRequest());

            return Ok(projects);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailsDto>> Get(int id)
        {
            var projectDetails = await _mediator.Send(new GetProjectDetailsRequest
            {
                Id = id
            });

            return Ok(projectDetails);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateProjectDto createDto)
        {
            var command = new CreateProjectCommand {CreateDto = createDto};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProjectDto updateDto)
        {
            var command = new UpdateProjectCommand {UpdateDto = updateDto};
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand
            {
                Id = id,
                Actor = "test.user"
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}