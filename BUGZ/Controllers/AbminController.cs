using BUGZ.LAYER_DATACCESS;
using BUGZ.LAYER_DOMAN;
using BUGZ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BUGZ.Controllers
{
    [Authorize(Roles = Contants.AbminRole)]
    public class AbminController : Controller
    {
        private readonly IDataccess _db;
        private readonly UserManager<AppUser> _um;
        private readonly RoleManager<IdentityRole> _rm;

        public AbminController(IDataccess db, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            _db = db;
            _um = um;
            _rm = rm;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllTheUsersPage()
        {
            var users = ((IRepository<AppUser>)_db).GetAll();

            var vm = new ViewModelForTheAbminWhenViewingAllUsers();

            var buns = new List<ViewModelForTheAbminWhenViewingAllUsers.UserBundle>();

            foreach (var user in users)
            {
                var bun = new ViewModelForTheAbminWhenViewingAllUsers.UserBundle();
                bun.Name = user.UserName;
                bun.Id = user.Id;
                bun.Roles = _um.GetRolesAsync(user).Result;
                buns.Add(bun);
            }

            vm.UserBundles = buns;

            return View(vm);
            
        }
        public IActionResult ThePageForJustOneUser(string id)
        {
            var User = ((IRepository<AppUser>)_db).Get(id);
            var vm = new ViewModelForAbminViewOneUser();
            vm.Name = User.UserName;
            vm.Id = User.Id;
            vm.UserRoles = _um.GetRolesAsync(User).Result;
            vm.OtherRoles = _rm.Roles.Where(r=>!vm.UserRoles.Contains(r.Name)).Select(r => r.Name);
            return View(vm);
        }

        [HttpPost]
        public IActionResult ThePageForJustOneUser(ViewModelForAbminViewOneUser vm)
        {
            string hahafunnyman = "memes";
            AppUser user = _um.Users.FirstOrDefault(u => u.Id == vm.Id);

            foreach (string s in _um.GetRolesAsync(user).Result)
            {
                _ = _um.RemoveFromRoleAsync(user, s).Result;
            }

            if(vm.UserRoles != null)
            foreach(string r in vm.UserRoles)
            {
                _ = _um.AddToRoleAsync(user, r).Result;
            }

            return Redirect("/abmin/alltheuserspage");
        }
    }
}
