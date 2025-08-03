namespace CMS.Application.Contracts.Persistence
{
    /// <summary>
    /// Repository interface for managing appointments.
    /// </summary>
    public interface IAppointmentRepository : IGenericRepository<Appointment>, IRepository
    {
    }
} 