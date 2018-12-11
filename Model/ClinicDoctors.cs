using System;
using System.Collections.Generic;

namespace Doctazer.API.Model
{
    public partial class ClinicDoctors
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
