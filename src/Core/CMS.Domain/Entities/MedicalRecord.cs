using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class MedicalRecord : AuditableEntity
    {
        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }

        public IList<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public IList<MedicalDocument> MedicalDocuments { get; set; } = new List<MedicalDocument>();
    }
}
