using CMS.Domain.Entities;

namespace CMS.Domain.Interfaces
{
    public interface ICreationTrackable
    {
        DateTime CreatedAt { get; set; }
        int? CreatedBy { get; set; }
        User? CreatedByUser { get; set; }
    }
}

