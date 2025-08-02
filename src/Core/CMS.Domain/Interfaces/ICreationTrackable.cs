namespace CMS.Domain.Interfaces
{
    public interface ICreationTrackable
    {
        DateTime CreatedAt { get; set; }
        int CreatedBy { get; set; }
    }
}

