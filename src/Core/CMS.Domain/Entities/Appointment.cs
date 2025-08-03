using CMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Appointment : AuditableEntity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public enAppointmentStatus Status { get; set; }
        public string? Notes { get; set; }
    
        
    }
}
