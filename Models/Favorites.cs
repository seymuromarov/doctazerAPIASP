using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
