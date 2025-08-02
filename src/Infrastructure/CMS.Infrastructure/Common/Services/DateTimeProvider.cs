using CMS.Application.Abstractions.Services;

namespace CMS.Infrastructure.Common.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

