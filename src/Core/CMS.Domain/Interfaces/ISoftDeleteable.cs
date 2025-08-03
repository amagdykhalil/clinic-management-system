using CMS.Domain.Entities;

namespace CMS.Domain.Interfaces
{
    public interface ISoftDeleteable
    {
         bool IsDeleted => DeletedAt.HasValue;
         DateTime? DeletedAt { get; set; }
         int? DeletedBy { get; set; }
         User? DeletedByUser { get; set; }
    }
}



