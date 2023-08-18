using BUGZ.LAYER_DATACCESS;
using BUGZ.LAYER_DOMAN;
using BUGZ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BUGZ.Controllers
{
    [Authorize(Roles = Contants.AnyoneRole)]
    public class SubController : Controller
    {
        private readonly IDataccess _db;
        private readonly UserManager<AppUser> _um;
        private readonly RoleManager<IdentityRole> _rm;

        public SubController(IDataccess db, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            _db = db;
            _um = um;
            _rm = rm;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MakeTicket()
        {
            var vm = new ViewModelMakeTicket();
            vm.ticketPriority = ((IRepository<TicketPriority>)_db).GetAll();
            vm.ticketTypes = ((IRepository<TicketType>)_db).GetAll();
            vm.projects = ((IRepository<Project>)_db).GetAll();

            return View(vm);
        }

        [HttpPost]
        public IActionResult MakeTicket(ViewModelMakeTicket vm)
        {
            Ticket tic = new Ticket()
            {
                Title = vm.Title,
                Description = vm.Description,
                TicketPriorityId = vm.ProirityId,
                TicketStatusId = ((IRepository<TicketStatus>)_db).GetAll().FirstOrDefault(ts=>ts.Name == "Recently Submitted").Id,
                TicketTypeId = vm.TypeId,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                ProjectId = vm.ProjectId,
                OwnerUserId = _um.GetUserId(User)
            };

            _db.Insert(tic);

            return RedirectToAction("Index");
        }
    }
}
