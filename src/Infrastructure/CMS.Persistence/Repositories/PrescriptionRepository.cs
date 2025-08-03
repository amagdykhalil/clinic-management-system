using CMS.Application.Contracts.Persistence;
using CMS.Domain.Entities;
using CMS.Persistence;
using CMS.Persistence.Repositories.Base;

namespace CMS.Persistence.Repositories
{
    public class PrescriptionRepository : GenericRepository<Prescription>, IPrescriptionRepository
    {
        private readonly AppDbContext _context;

        public PrescriptionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 