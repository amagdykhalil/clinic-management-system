using CMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class MedicalDocument : AuditableEntity
    {
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public decimal SizeInBytes { get; set; }
        public enFileStatus Status { get; set; }
    }
}
