using CMS.Application.Contracts.Persistence;
using CMS.Domain.Entities;
using CMS.Persistence;
using CMS.Persistence.Repositories.Base;

namespace CMS.Persistence.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
} 