using CMS.Application.Contracts.Persistence;
using CMS.Domain.Entities;
using CMS.Persistence;
using CMS.Persistence.Repositories.Base;

namespace CMS.Persistence.Repositories
{
    public class MedicalDocumentRepository : GenericRepository<MedicalDocument>, IMedicalDocumentRepository
    {
        private readonly AppDbContext _context;

        public MedicalDocumentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 