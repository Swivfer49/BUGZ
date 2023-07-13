using Layer_Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer_Dataccess
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
    }
}
