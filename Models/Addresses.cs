using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Addresses
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Long { get; set; }

        public virtual Cities City { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
