namespace CMS.Application.Contracts.Persistence
{
    /// <summary>
    /// Repository interface for managing medical documents.
    /// </summary>
    public interface IMedicalDocumentRepository : IGenericRepository<MedicalDocument>, IRepository
    {
    }
} 