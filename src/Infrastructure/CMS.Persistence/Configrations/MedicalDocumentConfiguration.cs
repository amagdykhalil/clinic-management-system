using CMS.Domain.Entities;
using CMS.Persistence.Configrations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Configrations
{
    public class MedicalDocumentConfiguration : AuditableEntityConfiguration<MedicalDocument>
    {
        public override void Configure(EntityTypeBuilder<MedicalDocument> builder)
        {
            base.Configure(builder);
            // Required  relations
            builder.HasOne(f => f.MedicalRecord)
                .WithMany(r => r.MedicalDocuments)
                .HasForeignKey(f => f.MedicalRecordId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(f => f.Path)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(f => f.ContentType)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.SizeInBytes)
                .HasColumnType("decimal(18,2)") 
                .IsRequired();

            
            builder.Property(f => f.Status)
                .HasColumnType("tinyint")
                .HasConversion<byte>()
                .HasComment("Tracks file status: 0=Pendding, 1=Ready.")
                .IsRequired();
        }
    }

}
