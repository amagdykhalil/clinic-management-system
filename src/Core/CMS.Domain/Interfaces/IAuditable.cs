using CMS.Domain.Entities;

namespace CMS.Domain.Interfaces
{
    public interface IAuditable : ICreationTrackable
    {
        DateTime? LastModifiedAt { get; set; }
        int? LastModifiedBy { get; set; }
        User? LastModifiedByUser { get; set; }
    }
}



