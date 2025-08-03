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
    public class AppointmentConfiguration : AuditableEntityConfiguration<Appointment>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);

            //Required relations
            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Service)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.Property(a => a.Time)
                .HasColumnType("time(0)") 
                .IsRequired();

            
            builder.Property(a => a.Status)
                .HasColumnType("tinyint")
                .HasConversion<byte>()
                .HasComment("Tracks appointment status: 0=Scheduled, 1=Confirmed, 2=InProgress, 3=Completed, 4=Cancelled, 5=NoShow, 6=Rescheduled.")
                .IsRequired();

            
            builder.Property(a => a.Notes)
                .HasMaxLength(1000); 
        }
    }

}
