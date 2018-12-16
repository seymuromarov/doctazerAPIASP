using Microsoft.AspNetCore.Identity;

namespace Doctazer.API.Data
{
    public class Role : IdentityRole<int>
    {
        public Role() : base()
        {
        }

        public Role(string roleName)
        {
            Name = roleName;
        }
    }
}