using CMS.Application.Contracts.Persistence;
using CMS.Domain.Entities;
using CMS.Persistence;
using CMS.Persistence.Repositories.Base;

namespace CMS.Persistence.Repositories
{
    public class SpecialtyRepository : GenericRepository<Specialty>, ISpecialtyRepository
    {
        private readonly AppDbContext _context;

        public SpecialtyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 