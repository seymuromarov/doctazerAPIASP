using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Doctors
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public int? SpecialityId { get; set; }
        public string About { get; set; }
        public DateTime? FromAvailabilities { get; set; }
        public DateTime? ToAvailabilities { get; set; }
    }
}
