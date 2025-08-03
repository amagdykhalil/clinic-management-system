namespace CMS.Application.Contracts.Persistence
{
    /// <summary>
    /// Repository interface for managing patients.
    /// </summary>
    public interface IPatientRepository : IGenericRepository<Patient>, IRepository
    {
    }
} 