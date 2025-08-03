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
    public class MedicalRecordConfiguration : AuditableEntityConfiguration<MedicalRecord>
    {
        public override void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            base.Configure(builder);
            // Optional Appointment relation
            builder.HasOne(r => r.Appointment)
                .WithOne() 
                .HasForeignKey<MedicalRecord>(r => r.AppointmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // Required  relations
            builder.HasOne(r => r.Patient)
                .WithMany(p => p.MedicalRecords) 
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(r => r.Doctor)
                .WithMany(d => d.MedicalRecords) 
                .HasForeignKey(r => r.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.Property(r => r.Diagnosis)
                .HasMaxLength(1000);

            builder.Property(r => r.Notes)
                .HasMaxLength(1000);
        }
    }

}
