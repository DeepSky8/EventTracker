using Microsoft.AspNet.Identity.EntityFramework;

namespace RSVP
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}