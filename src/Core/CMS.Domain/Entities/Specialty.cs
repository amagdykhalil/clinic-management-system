using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Specialty : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public IList<Doctor> Doctors { get; set; } = new List<Doctor>();

    }
}
