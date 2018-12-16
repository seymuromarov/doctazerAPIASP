using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Clinics
    {
        public Clinics()
        {
            Appointments = new HashSet<Appointments>();
            ClinicDoctors = new HashSet<ClinicDoctors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string About { get; set; }
        public string UserId { get; set; }

//        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<ClinicDoctors> ClinicDoctors { get; set; }
    }
}
