using CMS.Domain.Abstract;
using CMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Configrations.Base
{
    public abstract class AuditableSoftDeleteEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IAuditable, ISoftDeleteable
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasOne(a => a.CreatedByUser)
                .WithMany()
                .HasForeignKey(a => a.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.LastModifiedByUser)
                .WithMany()
                .HasForeignKey(a => a.LastModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.DeletedByUser)
                .WithMany()
                .HasForeignKey(a => a.DeletedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getutcdate()");

            builder.Property(a => a.LastModifiedAt)
                .HasColumnType("datetime");

            builder.Property(a => a.DeletedAt)
                .HasColumnType("datetime");
        }
    }
}
