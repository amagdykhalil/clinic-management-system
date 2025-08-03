using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Doctor : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SpecialtyId  { get; set; }
        public Specialty Specialty { get; set; }
        public short DayOfWeek { get; set; } // Fill from enWorkDays
        public TimeOnly ShiftStart { get; set; }
        public TimeOnly ShiftEnd { get; set; }
        public string Bio { get; set; }

        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
        public IList<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }
}
