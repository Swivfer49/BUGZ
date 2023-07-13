using BUGZ.LAYER_DOMAN;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BUGZ.LAYER_DATACCESS
{
    public class AppDBContext : IdentityDbContext<AppUser> , IDataccess
    {
    }
}
