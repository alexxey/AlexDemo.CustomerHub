using System.ComponentModel.DataAnnotations;

namespace AlexDemo.CustomerHub.Core.Application.Models.Identity
{
    public sealed class RegistrationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
