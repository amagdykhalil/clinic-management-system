using CMS.Domain.Entities;
using CMS.Persistence.Configrations.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Configrations
{
    public class UserConfiguration : CreationTrackableSoftDeleteEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {

           base.Configure(builder);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.SecondName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.ThirdName)
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.ProfileImagePath)
                .HasMaxLength(255);

            // Indexes
            builder.HasIndex(u => new { u.FirstName, u.SecondName, u.ThirdName, u.LastName })
                .HasDatabaseName("IX_User_FullName");

            // Soft delete filter
            builder.HasQueryFilter(p => p.DeletedAt == null);

            var hasher = new PasswordHasher<User>();
            var hashedPassword = hasher.HashPassword(null, "Admin@123");

            //seed initial user
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "خالد",
                    SecondName = "علي",
                    ThirdName = "احمد",
                    LastName = "موسى",
                    ProfileImagePath = null,
                    Email = "admin@clinic.com",
                    NormalizedEmail = "ADMIN@CLINIC.COM",
                    EmailConfirmed = true,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "AQAAAAIAAYagAAAAEKlDQPebJpmZtvrSmfp96ueOlyPNfq8ODXtLoiLEjHO5C034I2s6eTYo18aTd5EWGw==", //Admin@123
                    ConcurrencyStamp = "ee76eecb-cb58-4113-909e-5079f3f6c9f2",
                    SecurityStamp = "f3b2c1d4-5e6f-4a8b-9c0d-7e8f9a0b1c2d",
                    CreatedAt = new DateTime(2025, 08, 01, 13, 0, 0, DateTimeKind.Utc),
                    DeletedAt = null,
                    DeletedBy = null
                }
            );

        }
    }

}
