using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Configrations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            // Seed initial admin user roles
            builder.HasData(
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1 // Matches Role with Name = "Admin"
                }
            );
        }
    }
}
