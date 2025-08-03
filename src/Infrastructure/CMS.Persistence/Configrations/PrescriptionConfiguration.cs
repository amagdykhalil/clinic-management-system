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
    public class PrescriptionConfiguration : AuditableEntityConfiguration<Prescription>
    {
        public override void Configure(EntityTypeBuilder<Prescription> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.MedicalRecord)
                .WithMany(r => r.Prescriptions)
                .HasForeignKey(p => p.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.MedicationName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Dose)
                .HasMaxLength(100)
                .HasComment("Specifies medication dose, e.g., '1 drop', '10 units', '5 mL', '1 tablet'.");

            builder.Property(p => p.Route)
                .HasColumnType("tinyint")
                .HasConversion<byte?>()
                .HasComment("Medication route: 0=Oral(OR), 1=Intravenous(IV), 2=Intramuscular(IM), 3=Subcutaneous(SC), 4=Topical(TP), 5=Transdermal(TD), 6=Inhalation(INH), 7=Rectal(PR), 8=Vaginal(PV), 9=Ophthalmic(OPH), 10=Otic(OT), 11=Nasal(NAS), 12=Buccal(BU), 13=Sublingual(SL), 14=Intradermal(ID).");
;

            builder.Property(p => p.Duration)
                .HasMaxLength(100)
                .HasComment("Specifies duration of treatment, e.g., '5 days', '6 hours', '1 month'."); ;

            builder.Property(p => p.Frequency)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("Specifies how often medication is taken, e.g., '3 times daily', 'every 2 weeks'.");

            builder.Property(p => p.Notes)
                .HasMaxLength(1000);
        }
    }

}
