using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Appointments = new HashSet<Appointments>();
            ClinicDoctors = new HashSet<ClinicDoctors>();
            Favorites = new HashSet<Favorites>();
            PatientAttemps = new HashSet<PatientAttemps>();
            Reasons = new HashSet<Reasons>();
            Slots = new HashSet<Slots>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public int? SpecialityId { get; set; }
        public string About { get; set; }
        public DateTime? FromAvailabilities { get; set; }
        public DateTime? ToAvailabilities { get; set; }

        public virtual Specialities Speciality { get; set; }
//        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<ClinicDoctors> ClinicDoctors { get; set; }
        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual ICollection<PatientAttemps> PatientAttemps { get; set; }
        public virtual ICollection<Reasons> Reasons { get; set; }
        public virtual ICollection<Slots> Slots { get; set; }
    }
}
