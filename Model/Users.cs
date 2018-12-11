using System;
using System.Collections.Generic;

namespace Doctazer.API.Model
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? ValidType { get; set; }
        public string ValidMessage { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
