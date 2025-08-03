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
    public class PatientConfiguration : AuditableEntityConfiguration<Patient>
    {
        public override void Configure(EntityTypeBuilder<Patient> builder)
        {
            base.Configure(builder);
            
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.SecondName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ThirdName)
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            
            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20); // Consider validating format via annotation or FluentValidation

            builder.Property(p => p.Email)
                .HasMaxLength(255);

            
            builder.Property(p => p.Gender)
                .HasColumnType("tinyint")
                .HasConversion<byte>()
                .HasComment("Indicates gender: 0=Male, 1=Female.")
                .IsRequired();

            builder.Property(p => p.BirthDate)
                .IsRequired();

            builder.Property(p => p.Address)
                .HasMaxLength(500);

            builder.Property(p => p.Jop)
                .HasMaxLength(150);

            // Indexes
            builder.HasIndex(u => new { u.FirstName, u.SecondName, u.ThirdName, u.LastName })
                .HasDatabaseName("IX_Patient_FullName");
        }
    }

}
