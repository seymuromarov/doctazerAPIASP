using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int Id { get; set; }
        public string Az { get; set; }
        public string En { get; set; }
        public string Ru { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
