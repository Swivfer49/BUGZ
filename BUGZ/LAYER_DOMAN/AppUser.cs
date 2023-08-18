using Microsoft.AspNetCore.Identity;

namespace BUGZ.LAYER_DOMAN
{
    public class AppUser : IdentityUser
    {

        // Navigation properties
        public virtual ICollection<Ticket> AssignedTickets { get; set; }
        public virtual ICollection<Ticket> OwnedTickets { get; set; }
    }
}
