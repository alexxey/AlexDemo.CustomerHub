using Microsoft.AspNetCore.Identity;

namespace AlexDemo.CustomerHub.Identity.Models
{
    /// <summary>
    /// todo alex: add here all necessary information that is required for application user
    /// </summary>
    public sealed class ApplicationUser : IdentityUser
    {
        [ProtectedPersonalData]
        public string? PasswordSalt { get; set; }
    }
}
