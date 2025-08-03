using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Enums
{
    public enum enAppointmentStatus
    {
        Scheduled, 
        Confirmed, 
        InProgress, 
        Completed, 
        Cancelled, 
        NoShow, 
        Rescheduled
    }
}
