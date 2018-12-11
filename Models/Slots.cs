using System;
using System.Collections.Generic;

namespace Doctazer.API.Models
{
    public partial class Slots
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int? Filled { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
