using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Specialities
    {
        public Specialities()
        {
            Doctors = new HashSet<Doctors>();
        }

        public int Id { get; set; }
        public string Az { get; set; }
        public string En { get; set; }
        public string Ru { get; set; }

        public virtual ICollection<Doctors> Doctors { get; set; }
    }
}
