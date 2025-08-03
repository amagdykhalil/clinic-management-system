using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Configrations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            // Required relationships
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Specialty)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.Property(d => d.DayOfWeek)
                .IsRequired()
                .HasColumnType("smallint")
                .HasComment("Stores workday availability as a 7-bit binary mask (Sun→Sat). Example: 0110010 means available on Monday, Wednesday, and Friday.");

            builder.Property(d => d.ShiftStart)
                .IsRequired()
                .HasColumnType("time(0)");

            builder.Property(d => d.ShiftEnd)
                .IsRequired()
                .HasColumnType("time(0)");

            // Bio
            builder.Property(d => d.Bio)
                .IsRequired()
                .HasMaxLength(1000); 
        }
    }

}
