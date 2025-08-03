using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Service : AuditableEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
