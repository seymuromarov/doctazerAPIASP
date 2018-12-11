using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctazer.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Valid_type { get; set; }
        public string Valid_message { get; set; }
        public int Role_id { get; set; }
        public DateTime Created_at { get; set; }
    }
}
