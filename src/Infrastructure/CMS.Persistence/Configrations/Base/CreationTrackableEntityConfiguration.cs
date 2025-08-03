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
    public abstract class CreationTrackableEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, ICreationTrackable
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasOne(a => a.CreatedByUser)
                .WithMany()
                .HasForeignKey(a => a.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getutcdate()");

        }
    }
}
