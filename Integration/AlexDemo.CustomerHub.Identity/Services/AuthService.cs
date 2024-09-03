using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using AlexDemo.CustomerHub.Core.Application.Contracts.Identity;
using AlexDemo.CustomerHub.Core.Application.Models.Identity;
using AlexDemo.CustomerHub.Core.Application.ServiceProviders;
using AlexDemo.CustomerHub.Identity.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AlexDemo.CustomerHub.Identity.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;

        }

        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new Exception($"user with {authRequest.Email} is not found");
            }

            // todo alex : capture amount of attempts here
            // todo alex : update method to use password hash and salt here
            var loginResult = await _signInManager.PasswordSignInAsync(user, authRequest.Password, false, lockoutOnFailure: false);

            if (!loginResult.Succeeded)
            {
                throw new Exception($"Credentials for {authRequest.Email} are not valid");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateSecurityToken(user);

            AuthResponse authResponse = new AuthResponse
            {
                Id = user.Id,
                CompanyId = user.CompanyId,
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

            return authResponse;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var user = await _userManager.FindByNameAsync(registrationRequest.UserName);
            if (user != null)
            {
                throw new Exception($"user with {registrationRequest.UserName} already exists");
            }

            // option to generate hash and salt settings
            PasswordServiceProvider.CreatePasswordHash(registrationRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            // current approach : to be replaced with new one
            var passwordHashCurrent = new PasswordHasher<ApplicationUser>().HashPassword(null, registrationRequest.Password);

            var userToRegister = new ApplicationUser
            {
                Email = registrationRequest.Email,
                UserName = registrationRequest.UserName,
                CompanyId = registrationRequest.CompanyId,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                PasswordHash = passwordHashCurrent // Convert.ToBase64String(passwordHash),
                // PasswordSalt = Convert.ToBase64String(passwordSalt)
            };

            throw new NotImplementedException();
        }

        private async Task<JwtSecurityToken> GenerateSecurityToken(ApplicationUser user)
        {
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.UtcNow.ToUniversalTime().ToString()),
                new Claim(CustomClaimTypes.UserId, user.Id),
                new Claim(CustomClaimTypes.CompanyId, user.CompanyId.ToString(), "int")
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signInCredentials);

            return jwtSecurityToken;
        }
    }
}
