using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Configrations
{
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.ToTable("Specialties");

            builder.Property(s => s.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(1000);

            builder.HasIndex(s => s.Name).IsUnique();

            // Seed initial data
            builder.HasData(
                new Specialty { Id = 1, Name = "أطفال", Description = null },
                new Specialty { Id = 2, Name = "جلدية", Description = "أمراض الجلد والشعر" },
                new Specialty { Id = 3, Name = "باطنة", Description = null },
                new Specialty { Id = 4, Name = "قلب", Description = "أمراض القلب والأوعية الدموية" },
                new Specialty { Id = 5, Name = "أنف وأذن وحنجرة", Description = null },
                new Specialty { Id = 6, Name = "نساء وتوليد", Description = "رعاية الحمل والولادة" },
                new Specialty { Id = 7, Name = "جراحة عامة", Description = null },
                new Specialty { Id = 8, Name = "عيون", Description = "تشخيص وعلاج أمراض العين" },
                new Specialty { Id = 9, Name = "عظام", Description = "مشاكل المفاصل والهيكل العظمي" },
                new Specialty { Id = 10, Name = "مخ وأعصاب", Description = null }
            );

        }
    }

}
