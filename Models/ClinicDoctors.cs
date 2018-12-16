using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class ClinicDoctors
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Status { get; set; }

        public virtual Clinics Clinic { get; set; }
        public virtual Doctors Doctor { get; set; }
    }
}
