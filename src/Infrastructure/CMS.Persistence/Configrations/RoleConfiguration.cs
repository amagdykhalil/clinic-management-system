
using CMS.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.Configrations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                new IdentityRole<int> { Id = 1, Name = enRole.Admin.ToString(), NormalizedName = enRole.Admin.ToString().ToUpper() },
                new IdentityRole<int> { Id = 2, Name = enRole.Doctor.ToString(), NormalizedName = enRole.Doctor.ToString().ToUpper() },
                new IdentityRole<int> { Id = 3, Name = enRole.Receptionist.ToString(), NormalizedName = enRole.Receptionist.ToString().ToUpper() }
            );
        }
    }
}
