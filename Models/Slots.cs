using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Slots
    {
        public Slots()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int? Filled { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
