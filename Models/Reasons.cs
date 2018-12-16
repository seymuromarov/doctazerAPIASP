using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Reasons
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Name { get; set; }

        public virtual Doctors Doctor { get; set; }
    }
}
