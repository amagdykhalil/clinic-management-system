using CMS.Domain.Enums;

namespace CMS.Domain.Entities
{
    public class Patient: AuditableEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public enGender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Jop{ get; set; }

        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
        public IList<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }
}
