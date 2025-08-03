using CMS.Domain.Enums;

namespace CMS.Domain.Entities
{
    public class Prescription : AuditableEntity
    {
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public string MedicationName { get; set; }
        public string? Dose { get; set; }
        public enMedicationRoute? Route { get; set; }
        public string? Duration { get; set; }
        public string Frequency { get; set; }
        public string? Notes { get; set; }
    
    }
}
