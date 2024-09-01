using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.Identity.Configurations
{
    public sealed class UserRoleConfiguration :  IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "57B5F943-7B64-4B9E-9616-2963019F29DB",
                    UserId = "B1228239-3B42-47F7-A9B7-22DEC0065942"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "BDE81506-8045-4AF0-872D-8B523376D6A9",
                    UserId = "832BE41E-7C11-43A0-9E03-DA328193C93E"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "B1228239-3B42-47F7-A9B7-22DEC0065942",
                    UserId = "FB436184-620B-4549-8BC6-85494C026011"
                }
            );
        }
    }
}
