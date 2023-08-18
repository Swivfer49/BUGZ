using BUGZ.LAYER_DATACCESS;
using BUGZ.LAYER_DOMAN;
using BUGZ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BUGZ.Controllers
{
    [Authorize(Roles = $"{Contants.AnyoneRole}, {Contants.DeveloperRole}")]

    public class TicketController : Controller
    {

        private readonly IDataccess _db;
        private readonly UserManager<AppUser> _um;
        private readonly RoleManager<IdentityRole> _rm;

        public TicketController(IDataccess db, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            _db = db;
            _um = um;
            _rm = rm;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllPertainingTickets()
        {
            var user = _um.GetUserAsync(User).Result;

            IEnumerable<Ticket> ticket = _db.GetMyTickets(user.Id);

            return View(ticket.Select(t =>
            new ViewModelTicketPassIn()
            {
                Title = t.Title,
                Description = t.Description,
                Priority = t.TicketPriority.Name,
                Project = t.Project.Name,
                Type = t.TicketType.Name,
                Status = t.TicketStatus.Name,
                Created = t.Created.ToShortDateString(),
                Updated = t.Updated.ToShortDateString()
            }
            ));
        }
    }
}
