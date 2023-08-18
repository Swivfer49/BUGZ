using Microsoft.VisualStudio.TestTools.UnitTesting;
using BUGZ.LAYER_DOMAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using BUGZ.LAYER_DATACCESS;
using Microsoft.EntityFrameworkCore;

namespace BUGZ.LAYER_DOMAN.Tests
{
    [TestClass()]
    public class AuthorizationHandlerTests
    {
        [TestMethod()]
        public async Task SubTicketHandlerTestSuccess()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");

            var reggie = MakeRequirements(Contants.ViewTicketDetailsName);

            var roberto = new Ticket()
            {
                Id = Guid.NewGuid(),
                OwnerUserId = "7"
            };

            var user = MakeAClaim("Dan", Contants.AnyoneRole);

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new SubTicketAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(context.HasSucceeded, true);

        }

        [TestMethod()]
        public async Task SubTicketHandlerTesteFail()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");

            var reggie = MakeRequirements(Contants.ViewTicketDetailsName);

            var roberto = new Ticket()
            {
                Id = Guid.NewGuid(),
                OwnerUserId = "Gerald"
            };

            var user = MakeAClaim("Dan", Contants.AnyoneRole);

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new SubTicketAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(context.HasSucceeded, false);

        }

        [TestMethod()]
        public async Task AbminHandlerTestSuccess()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");

            var reggie = MakeRequirements(Contants.ViewTicketDetailsName);

            var roberto = new Ticket()
            {
                Id = Guid.NewGuid(),
                OwnerUserId = "7"
            };

            var user = MakeAClaim("Dan", Contants.AbminRole);

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new AbminAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task AbminHandlerTestFail()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");

            var reggie = MakeRequirements(Contants.CreateTicketName);

            var roberto = new Ticket()
            {
                Id = Guid.NewGuid(),
                OwnerUserId = "7"
            };

            var user = MakeAClaim("Dan", Contants.AbminRole);

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new AbminAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task PMHandlerTestSuccess()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");

            var fakeContextGiven = GiveMeSomeContext();

            var reggie = MakeRequirements(Contants.ViewTicketDetailsName);

            var Prodney = new Project()
            {
                Id = Guid.NewGuid(),
                Name = "Ooga Booga"
            };

            var roberto = new Ticket()
            {
                Id = Guid.NewGuid(),
                OwnerUserId = "7",
                ProjectId = Prodney.Id
            };

            var user = MakeAClaim("Dan", Contants.ManagersRole);

            var pruz = new ProjectUser()
            {
                UserId = "7",
                ProjectId = Prodney.Id
            };

            fakeContextGiven.As<IRepository<ProjectUser>>().Setup(cg => cg.GetAll()).Returns(new List<ProjectUser>() { pruz });

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new PMTicketAuthorizationHandler(fakeManagerOfTheUsers.Object,fakeContextGiven.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task PMHandlerTestFailure()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("Haha, No U Cant :)");

            var fakeContextGiven = GiveMeSomeContext();

            var reggie = MakeRequirements(Contants.ViewTicketDetailsName);

            var Prodney = new Project()
            {
                Id = Guid.NewGuid(),
                Name = "Ooga Booga"
            };

            var roberto = new Ticket()
            {
                Id = Guid.NewGuid(),
                OwnerUserId = "7",
                ProjectId = Prodney.Id
            };

            var user = MakeAClaim("Dan", Contants.ManagersRole);

            var pruz = new ProjectUser()
            {
                UserId = "7",
                ProjectId = Prodney.Id
            };

            fakeContextGiven.As<IRepository<ProjectUser>>().Setup(cg => cg.GetAll()).Returns(new List<ProjectUser>() { pruz });

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new PMTicketAuthorizationHandler(fakeManagerOfTheUsers.Object, fakeContextGiven.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task PMHandlerTestFailureNoPermissionToAssignPeopleToRoles()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");

            var fakeContextGiven = GiveMeSomeContext();

            var reggie = MakeRequirements(Contants.AssignRoleName);

            var Prodney = new Project()
            {
                Id = Guid.NewGuid(),
                Name = "Ooga Booga"
            };

            var roberto = new Ticket()
            {
                Id = Guid.NewGuid(),
                OwnerUserId = "7",
                ProjectId = Prodney.Id
            };

            var user = MakeAClaim("Dan", Contants.ManagersRole);

            var pruz = new ProjectUser()
            {
                UserId = "7",
                ProjectId = Prodney.Id
            };

            fakeContextGiven.As<IRepository<ProjectUser>>().Setup(cg => cg.GetAll()).Returns(new List<ProjectUser>() { pruz });

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new PMTicketAuthorizationHandler(fakeManagerOfTheUsers.Object, fakeContextGiven.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task PMAssignToTicketHandlerTestSuccess()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();


            var reggie = MakeRequirements(Contants.AssignToTicketName);

            var roberto = new AppUser()
            {
                Id = "hehehaha funny id name :P",
            };

            fakeManagerOfTheUsers.Setup
                (
                um => um.IsInRoleAsync(
                    It.Is<AppUser>(u => u == roberto),
                    It.Is<string>(s => s == Contants.DeveloperRole)
                    )
                ).ReturnsAsync(true);

            var user = MakeAClaim("Dan", Contants.ManagersRole);

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new PMUserAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task PMAssignToTicketHandlerTestFailure()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();


            var reggie = MakeRequirements(Contants.AssignToTicketName);

            var roberto = new AppUser()
            {
                Id = "hehehaha funny id name :P",
            };

            fakeManagerOfTheUsers.Setup
                (
                um => um.IsInRoleAsync(
                    It.Is<AppUser>(u => u == roberto),
                    It.Is<string>(s => s == Contants.DeveloperRole)
                    )
                ).ReturnsAsync(false);
            //not delevolper

            var user = MakeAClaim("Dan", Contants.ManagersRole);

            var context = new AuthorizationHandlerContext(reggie, user, roberto);

            var handle = new PMUserAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task PMProjectHandlerTestYes()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.EditProjectDetailsName,
                Contants.ViewProjectName,
                Contants.CreateProjectName,
                Contants.ArchiveProjectName);

            var Prodney = new Project()
            {
                Id = Guid.NewGuid(),
                Name = "Ooga Booga"
            };

            var user = MakeAClaim("Dan", Contants.ManagersRole);

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new PMProjectAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task PMProjectHandlerTestNo()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(Contants.EditTicketStatusName);

            var Prodney = new Project()
            {
                Id = Guid.NewGuid(),
                Name = "Ooga Booga"
            };

            var user = MakeAClaim("Dan", Contants.ManagersRole);

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new PMProjectAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task DevTicketHandlerTestYes()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.EditTicketPriorityName,
                Contants.EditTicketStatusName,
                Contants.ViewTicketDetailsName,
                Contants.EditTicketName,
                Contants.AddAttachmentName,
                Contants.AddCommentName);

            var Prodney = new Ticket()
            {
                AssignedUserId = "7"
            };

            var user = MakeAClaim("Dan", Contants.DeveloperRole);

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new DeveloperTicketAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task DevTicketHandlerTestNo()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.EditProjectDetailsName);

            var Prodney = new Ticket()
            {
                AssignedUserId = "7"
            };

            var user = MakeAClaim("Dan", Contants.DeveloperRole);

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new DeveloperTicketAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task DevProjectHandlerTestYes()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();
            var fakeC = GiveMeSomeContext();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.ViewProjectName);

            var Prodney = new Project()
            {
                Id = Guid.NewGuid(),
                Name = "The project that has all the options for different colored rocks which you can put in a rock garden and stuff, i really want to make that game, i think it would be very fun."
            };

            var user = MakeAClaim("Dan", Contants.DeveloperRole);

            var pruz = new ProjectUser()
            {
                UserId = "7",
                ProjectId = Prodney.Id
            };

            fakeC.As<IRepository<ProjectUser>>().Setup(cg => cg.GetAll()).Returns(new List<ProjectUser>() { pruz });
            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new DeveloperProjectAuthorizationHandler(fakeManagerOfTheUsers.Object,fakeC.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task DevProjectHandlerTestNo()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();
            var fakeC = GiveMeSomeContext();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.AddAttachmentName);

            var Prodney = new Project()
            {
                Id = Guid.NewGuid(),
                Name = "The project that has all the options for different colored rocks which you can put in a rock garden and stuff, i really want to make that game, i think it would be very fun."
            };

            var user = MakeAClaim("Dan", Contants.DeveloperRole);

            var pruz = new ProjectUser()
            {
                UserId = "7",
                ProjectId = Prodney.Id
            };

            fakeC.As<IRepository<ProjectUser>>().Setup(cg => cg.GetAll()).Returns(new List<ProjectUser>() { pruz });
            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new DeveloperProjectAuthorizationHandler(fakeManagerOfTheUsers.Object, fakeC.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task SubProjectHandlerTestYes()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();
            var fakeC = GiveMeSomeContext();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.ViewProjectName,
                Contants.CreateTicketName) ;

            var Prodney = new Project()
            {
                Id = Guid.NewGuid(),
                Name = "Hey Alex, you should try Rain World, it's cool"
            };

            var pruz = new ProjectUser()
            {
                UserId = "7",
                ProjectId = Prodney.Id
            };


            var user = MakeAClaim("Dan", Contants.AnyoneRole);
            fakeC.As<IRepository<ProjectUser>>().Setup(cg => cg.GetAll()).Returns(new List<ProjectUser>() { pruz });

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new SubProjectAuthorizationHandler(fakeManagerOfTheUsers.Object,fakeC.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task AverageCommentHandlerTestYes()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();
            var fakeC = GiveMeSomeContext();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.EditCommentName,
                Contants.DeleteCommentName);

            var Prodney = new TicketComment()
            {
                UserId = "7"
            };

            var user = MakeAClaim("Dan", Contants.AnyoneRole);

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new AverageCommentAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task AverageCommentHandlerTestNo()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();
            var fakeC = GiveMeSomeContext();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.EditCommentName,
                Contants.DeleteCommentName);

            var Prodney = new TicketComment()
            {
                UserId = "Not Your ID, HAHA"
            };

            var user = MakeAClaim("Dan", Contants.AnyoneRole);

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new AverageCommentAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task AverageAttachmentHandlerTestYes()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();
            var fakeC = GiveMeSomeContext();

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.EditAttachmentName,
                Contants.DeleteAttachmentName);

            var Prodney = new TicketAttachment()
            {
                UserId = "7"
            };

            var user = MakeAClaim("Dan", Contants.AnyoneRole);

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new AverageAttachmentAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(true, context.HasSucceeded);

        }

        [TestMethod()]
        public async Task AverageAttachmentHandlerTestNo()
        {
            var fakeManagerOfTheUsers = IWantToSpeakToYourManager();
            var fakeC = GiveMeSomeContext();
            //hey alex, tell me if you see this :)

            fakeManagerOfTheUsers.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("7");
            var reggie = MakeRequirements(
                Contants.EditAttachmentName,
                Contants.DeleteAttachmentName);

            var Prodney = new TicketAttachment()
            {
                UserId = "Not Your ID, HAHA"
            };

            var user = MakeAClaim("Dan", Contants.AnyoneRole);

            var context = new AuthorizationHandlerContext(reggie, user, Prodney);

            var handle = new AverageAttachmentAuthorizationHandler(fakeManagerOfTheUsers.Object);

            await handle.HandleAsync(context);

            Assert.AreEqual(false, context.HasSucceeded);

        }

        

        #region Help, aahhhhhh!

        private Mock<UserManager<AppUser>> IWantToSpeakToYourManager()
        {
            var candyStore = new Mock<IUserStore<AppUser>>();
            var fakeManagerOfTheUsers = new Mock<UserManager<AppUser>>(candyStore.Object, null, null, null, null, null, null, null, null);
            return fakeManagerOfTheUsers;
        }

        private Mock<IDataccess> GiveMeSomeContext()
        {
            return new Mock<IDataccess>();
        } 

        private ClaimsPrincipal MakeAClaim(string UserName, params string[] Roles)
        {
            Claim[] claims = new Claim[Roles.Length+1];
            claims[0] = new Claim(ClaimsIdentity.DefaultNameClaimType, UserName);
            for(int i = 0; i < Roles.Length; i++)
            {
                claims[i+1] = new Claim(ClaimsIdentity.DefaultRoleClaimType, Roles[i]);
            }
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    claims,
                    "Basic")
                );
            return user;
        }

        private OperationAuthorizationRequirement MakeRequirement(string reqName)
        {
            return new OperationAuthorizationRequirement()
            {
                Name = reqName
            };
        }

        private IEnumerable<OperationAuthorizationRequirement> MakeRequirements(params string[] strings)
        {
            List<OperationAuthorizationRequirement> result = new List<OperationAuthorizationRequirement>();
            foreach (string s in strings)
            {
                result.Add(MakeRequirement(s));
            }
            return result;
        }

        #endregion
    }
}