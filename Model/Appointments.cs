using System;
using System.Collections.Generic;

namespace Doctazer.API.Model
{
    public partial class Appointments
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int? ClinicId { get; set; }
    }
}
