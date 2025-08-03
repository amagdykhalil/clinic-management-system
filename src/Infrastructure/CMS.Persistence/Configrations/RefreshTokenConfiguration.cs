using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Configrations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasOne(t => t.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Token)
                .HasMaxLength(512)
                .IsRequired();

            builder.HasIndex(t => t.Token)
                .IsUnique();

            builder.HasIndex(r => new { r.UserId, r.RevokedOn, r.ExpiresOn })
                .HasDatabaseName("IX_RefreshToken_ActiveLookup");

        }
    }
}
