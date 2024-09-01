using AlexDemo.CustomerHub.Core.Application.Models.Identity;

namespace AlexDemo.CustomerHub.Core.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);

        Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
    }
}
