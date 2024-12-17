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
                // alexdemo
                new IdentityUserRole<string>
                {
                    RoleId = "57B5F943-7B64-4B9E-9616-2963019F29DB",
                    UserId = "B1228239-3B42-47F7-A9B7-22DEC0065942"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "BDE81506-8045-4AF0-872D-8B523376D6A9",
                    UserId = "76B6EF44-5415-4209-9163-55F6B7F50C42"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "B1228239-3B42-47F7-A9B7-22DEC0065942",
                    UserId = "6CC0E7C7-AA6D-4FAA-A055-E799C5F861A1"
                },
                // bentley
                new IdentityUserRole<string>
                {
                    RoleId = "57B5F943-7B64-4B9E-9616-2963019F29DB",
                    UserId = "A3AD1AE6-A6A1-4317-B660-E29AB0BEC1BF"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "BDE81506-8045-4AF0-872D-8B523376D6A9",
                    UserId = "832BE41E-7C11-43A0-9E03-DA328193C93E"
                },
                // aston
                new IdentityUserRole<string>
                {
                    RoleId = "57B5F943-7B64-4B9E-9616-2963019F29DB",
                    UserId = "FB436184-620B-4549-8BC6-85494C026011"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "BDE81506-8045-4AF0-872D-8B523376D6A9",
                    UserId = "1AA7B5AC-484E-4A2C-B6CB-D0F1286795D5"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "BDE81506-8045-4AF0-872D-8B523376D6A9",
                    UserId = "6150F338-7A79-439B-AC35-F20A4A6EA954"
                }
            );
        }
    }
}
