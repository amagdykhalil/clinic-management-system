namespace CMS.Application.Contracts.Persistence
{
    /// <summary>
    /// Repository interface for managing medical records.
    /// </summary>
    public interface IMedicalRecordRepository : IGenericRepository<MedicalRecord>, IRepository
    {
    }
} 