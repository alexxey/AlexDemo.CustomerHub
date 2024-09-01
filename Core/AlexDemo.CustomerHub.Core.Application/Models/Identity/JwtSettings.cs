namespace AlexDemo.CustomerHub.Core.Application.Models.Identity
{
    public sealed class JwtSettings
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int DurationInMinutes { get; set; }
    }
}
