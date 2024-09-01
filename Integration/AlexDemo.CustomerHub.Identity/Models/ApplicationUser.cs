using Microsoft.AspNetCore.Identity;

namespace AlexDemo.CustomerHub.Identity.Models
{
    /// <summary>
    /// todo alex: add here all necessary information that is required for application user
    /// </summary>
    public sealed class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
