using BUGZ.LAYER_DOMAN;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BUGZ.LAYER_DATACCESS
{
    public class Seedata
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new AppDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDBContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@dbdb.com");
                await EnsureRole(serviceProvider, adminID, Contants.AbminRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@dbdb.com");
                await EnsureRole(serviceProvider, managerID, Contants.ManagersRole);

                var devID = await EnsureUser(serviceProvider, testUserPw, "daniel@dbdb.com");
                await EnsureRole(serviceProvider, devID, Contants.DeveloperRole);

                // allowed user can create and edit contacts that they create
                var subID = await EnsureUser(serviceProvider, testUserPw, "herbert.mcgee@dbdb.com");
                await EnsureRole(serviceProvider, subID, Contants.AnyoneRole);

                SeedDB(context, adminID);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<AppUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new AppUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<AppUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        public static void SeedDB(IDataccess context, string adminID)
        {
            if (!HasAnyInBox<TicketPriority>(context))
            {
                TicketPriority lowPri = new TicketPriority()
                {
                    Name = "Low"
                };
                TicketPriority highPri = new TicketPriority()
                {
                    Name = "Hight"
                };
                TicketPriority medPri = new TicketPriority()
                {
                    Name = "Medium"
                };

                HelpPutInTheBox(context, lowPri, highPri, medPri);
            }

            if (!HasAnyInBox<Project>(context))
            {
                Project proGeraldMan = new Project()
                {
                    Name = "GeraldMan, destroyer of worlds"
                };
                Project proMTShovel = new Project()
                {
                    Name = "Upside-down Mountain Shovel"
                };

                HelpPutInTheBox(context, proGeraldMan, proMTShovel);
            }

            if (!HasAnyInBox<TicketType>(context))
            {
                TicketType typeCrash = new TicketType()
                {
                    Name = "Crash"
                };
                TicketType typeVisual = new TicketType()
                {
                    Name = "Visual Glitch"
                };
                TicketType typeComplaint = new TicketType()
                {
                    Name = "Complaint"
                };
                TicketType typeExploit = new TicketType()
                {
                    Name = "Unfair Exploit"
                };

                HelpPutInTheBox(context, typeComplaint, typeCrash, typeExploit, typeVisual);
            }

            if (!HasAnyInBox<TicketStatus>(context))
            {
                TicketStatus statSubmit = new TicketStatus()
                {
                    Name = "Recently Submitted"
                };
                TicketStatus statReviewed = new TicketStatus()
                {
                    Name = "Reviewed"
                };
                TicketStatus statOngoing = new TicketStatus()
                {
                    Name = "Ongoing"
                };
                TicketStatus statAwaiting = new TicketStatus()
                {
                    Name = "Needs More Information"
                };
                TicketStatus statDone = new TicketStatus()
                {
                    Name = "Closed"
                };

                HelpPutInTheBox(context, statSubmit, statReviewed, statOngoing, statDone, statAwaiting);
            }
        }

        private static void HelpPutInTheBox<T>(IRepository<T> db, params T[] items) where T : class
        {
            foreach (T item in items)
            {
                db.Insert(item);
            }
        }

        private static bool HasAnyInBox<T>(IRepository<T> db) where T : class
        {
            return (db.GetAll().Count() != 0);
        }
    }
}
