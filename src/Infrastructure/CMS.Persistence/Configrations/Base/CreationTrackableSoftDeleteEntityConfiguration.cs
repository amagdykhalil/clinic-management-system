using CMS.Domain.Abstract;
using CMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CMS.Persistence.Configrations.Base
{
    public abstract class CreationTrackableSoftDeleteEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, ISoftDeleteable, ICreationTrackable
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasOne(a => a.CreatedByUser)
             .WithMany()
             .HasForeignKey(a => a.CreatedBy)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.DeletedByUser)
               .WithMany()
               .HasForeignKey(a => a.DeletedBy)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getutcdate()");

            builder.Property(a => a.DeletedAt)
                .HasColumnType("datetime");

        }
    }
}
