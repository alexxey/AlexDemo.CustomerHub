using AlexDemo.CustomerHub.Core.Application.Contracts.Identity;
using AlexDemo.CustomerHub.Core.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlexDemo.CustomerHub.Presentation.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AccountController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<ActionResult<AuthResponse>> Login(AuthRequest loginRequest)
        {
            var loginResponse = await _authenticationService.Login(loginRequest);
            return Ok(loginResponse);
        }

        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest registrationRequest)
        {
            var registrationResponse = await _authenticationService.Register(registrationRequest);
            return Ok(registrationResponse);
        }
    }
}
