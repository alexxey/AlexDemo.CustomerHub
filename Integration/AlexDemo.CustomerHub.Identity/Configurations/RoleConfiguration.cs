using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.Identity.Configurations
{
    public sealed class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "57B5F943-7B64-4B9E-9616-2963019F29DB",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "BDE81506-8045-4AF0-872D-8B523376D6A9",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "B1228239-3B42-47F7-A9B7-22DEC0065942",
                    Name = "Visitor",
                    NormalizedName = "VISITOR"
                }
            );
        }
    }
}
