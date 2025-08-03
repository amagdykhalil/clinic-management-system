using CMS.Domain.Entities;
using CMS.Persistence.Configrations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Configrations
{
    public class ServiceConfiguration : AuditableEntityConfiguration<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            base.Configure(builder);    
            builder.ToTable("Services");

            builder.Property(s => s.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.Price)
                .HasColumnType("decimal(18,2)") 
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(1000);

            // Seed initial data
            builder.HasData(
                new Service
                {
                    Id = 1,
                    Name = "كشف",
                    Price = 100.00m,
                    Description = "كشف أولي",
                    CreatedAt = new DateTime(2025, 08, 01, 13, 0, 0, DateTimeKind.Utc),
                },
                new Service
                {
                    Id = 2,
                    Name = "متابعه",
                    Price = 50.00m,
                    Description = "جلسة متابعة",
                    CreatedAt = new DateTime(2025, 08, 01, 13, 0, 0, DateTimeKind.Utc),
                },
                new Service
                {
                    Id = 3,
                    Name = "استشاره",
                    Price = 75.00m,
                    Description = "استشارة طبية",
                    CreatedAt = new DateTime(2025, 08, 01, 13, 0, 0, DateTimeKind.Utc),
                }
            );

        }
    }

}
