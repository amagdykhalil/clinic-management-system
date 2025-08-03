using CMS.Domain.Entities;

namespace CMS.Domain.Abstract
{
    public abstract class CreationTrackableEntity : Entity, ICreationTrackable
    {
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public User? CreatedByUser { get; set; }
    }

}

