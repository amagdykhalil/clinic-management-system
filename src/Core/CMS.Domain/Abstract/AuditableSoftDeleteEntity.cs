using CMS.Domain.Entities;
using CMS.Domain.Interfaces;

namespace CMS.Domain.Abstract
{
    public abstract class AuditableSoftDeleteEntity : Entity, IAuditable, ISoftDeleteable
    {
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public User? LastModifiedByUser { get; set; }
        public User? CreatedByUser { get; set; }
        public User? DeletedByUser { get; set; }
    }
}



