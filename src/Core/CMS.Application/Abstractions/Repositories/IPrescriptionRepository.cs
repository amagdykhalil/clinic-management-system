namespace CMS.Application.Contracts.Persistence
{
    /// <summary>
    /// Repository interface for managing prescriptions.
    /// </summary>
    public interface IPrescriptionRepository : IGenericRepository<Prescription>, IRepository
    {
    }
} 