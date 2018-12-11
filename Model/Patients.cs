using System;
using System.Collections.Generic;

namespace Doctazer.API.Model
{
    public partial class Patients
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string Phone { get; set; }
    }
}
