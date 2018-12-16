using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
            Favorites = new HashSet<Favorites>();
            PatientAttemps = new HashSet<PatientAttemps>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string Phone { get; set; }

//        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual ICollection<PatientAttemps> PatientAttemps { get; set; }
    }
}
