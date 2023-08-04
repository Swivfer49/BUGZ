using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BUGZ.LAYER_DATACCESS;

namespace BUGZ.LAYER_DOMAN
{
    #region abmin
    //abmin
    public class AbminAuthorizationHandler
               : AuthorizationHandler<OperationAuthorizationRequirement, Ticket>
    {
        UserManager<AppUser> _userManager;

        public AbminAuthorizationHandler(UserManager<AppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Ticket resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If is abmin, is abmin

            if (
                context.User.IsInRole(Contants.AbminRole) && 
                (requirement.Name != Contants.CreateTicketName)
                )
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
    #endregion

    #region pm

    //the pm with the ticket
    public class PMTicketAuthorizationHandler
           : AuthorizationHandler<OperationAuthorizationRequirement, Ticket>
    {
        UserManager<AppUser> _userManager;
        IDataccess _appDBContext;

        public PMTicketAuthorizationHandler(UserManager<AppUser>
            userManager, IDataccess appDBContext)
        {
            _userManager = userManager;
            _appDBContext = appDBContext;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Ticket resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (
                !context.User.IsInRole(Contants.ManagersRole)
                )
            {
                return Task.CompletedTask;
            }

            switch (requirement.Name)
            {
                //yes
                case Contants.EditTicketStatusName:
                    context.Succeed(requirement);
                    break;
                //only tickets that for projects that are the ones that belong-ish to this person
                case Contants.ViewTicketDetailsName:
                case Contants.EditTicketName:
                case Contants.EditCommentName:
                case Contants.EditAttachmentName:
                case Contants.DeleteCommentName:
                case Contants.DeleteAttachmentName:
                case Contants.AddCommentName:
                case Contants.AddAttachmentName:
                case Contants.ViewHistoryName:
                case Contants.EditTicketPriorityName:
                    if (((IRepository<ProjectUser>)_appDBContext).GetAll().Any(pu => (pu.ProjectId == resource.ProjectId && pu.UserId == _userManager.GetUserId(context.User))))
                    {
                        context.Succeed(requirement);
                    }
                    break;
            }

            return Task.CompletedTask;
        }
    }


    //pretty much only for when a project manager tries to assign a user to a ticket
    public class PMUserAuthorizationHandler
           : AuthorizationHandler<OperationAuthorizationRequirement, AppUser>
    {
        UserManager<AppUser> _userManager;

        public PMUserAuthorizationHandler(UserManager<AppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   AppUser resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (
                !context.User.IsInRole(Contants.ManagersRole)
                )
            {
                return Task.CompletedTask;
            }

            if (requirement.Name == Contants.AssignToTicketName)
            {
                if (_userManager.IsInRoleAsync(resource, Contants.DeveloperRole).Result)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }

    public class PMProjectAuthorizationHandler
           : AuthorizationHandler<OperationAuthorizationRequirement, Project>
    {
        UserManager<AppUser> _userManager;

        public PMProjectAuthorizationHandler(UserManager<AppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Project resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (
                !context.User.IsInRole(Contants.ManagersRole)
                )
            {
                return Task.CompletedTask;
            }

            if (requirement.Name == Contants.CreateProjectName || 
                requirement.Name == Contants.ViewProjectName ||
                requirement.Name == Contants.ArchiveProjectName || 
                requirement.Name == Contants.EditProjectDetailsName)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    #endregion

    #region average

    #region dev
    //dev ticket
    public class DeveloperTicketAuthorizationHandler
               : AuthorizationHandler<OperationAuthorizationRequirement, Ticket>
    {
        UserManager<AppUser> _userManager;

        public DeveloperTicketAuthorizationHandler(UserManager<AppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Ticket resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If is abmin, is abmin

            if (
                !context.User.IsInRole(Contants.DeveloperRole)
                )
            {
                return Task.CompletedTask;
            }

            switch (requirement.Name)
            {
                case Contants.EditTicketPriorityName:
                case Contants.EditTicketStatusName:
                case Contants.ViewTicketDetailsName:
                case Contants.EditTicketName:
                case Contants.AddAttachmentName:
                case Contants.AddCommentName:
                    if (resource.AssignedUserId == _userManager.GetUserId(context.User))
                    {
                        context.Succeed(requirement);
                    }
                    break;
            }

            return Task.CompletedTask;
        }
    }
    public class DeveloperProjectAuthorizationHandler
           : AuthorizationHandler<OperationAuthorizationRequirement, Project>
    {
        IDataccess _appDBContext;
        UserManager<AppUser> _userManager;

        public DeveloperProjectAuthorizationHandler(UserManager<AppUser> userManager, IDataccess appDBContext)
        {
            _userManager = userManager;
            _appDBContext = appDBContext;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Project resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (
                !context.User.IsInRole(Contants.DeveloperRole)
                )
            {
                return Task.CompletedTask;
            }

            switch (requirement.Name)
            {
                case Contants.ViewProjectName:
                    if (((IRepository<ProjectUser>)_appDBContext).GetAll().Any(pu => pu.UserId == _userManager.GetUserId(context.User) && pu.ProjectId == resource.Id))
                    {
                        context.Succeed(requirement);
                    }
                    break;
            }

            return Task.CompletedTask;
        }
    }
    #endregion

    #region sub

    public class SubTicketAuthorizationHandler
           : AuthorizationHandler<OperationAuthorizationRequirement, Ticket>
    {
        UserManager<AppUser> _userManager;

        public SubTicketAuthorizationHandler(UserManager<AppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Ticket resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (
                !context.User.IsInRole(Contants.AnyoneRole)
                )
            {
                return Task.CompletedTask;
            }

            switch (requirement.Name)
            {
                case Contants.ViewTicketDetailsName:
                case Contants.EditTicketName:
                case Contants.AddAttachmentName:
                case Contants.AddCommentName:
                case Contants.EditTicketPriorityName:
                case Contants.DeleteAttachmentName:
                case Contants.DeleteCommentName:
                case Contants.ViewHistoryName:
                    if (resource.OwnerUserId == _userManager.GetUserId(context.User))
                    {
                        context.Succeed(requirement);
                    }
                    break;
            }

            return Task.CompletedTask;
        }
    }

    public class SubProjectAuthorizationHandler
           : AuthorizationHandler<OperationAuthorizationRequirement, Project>
    {
        IDataccess _appDBContext;
        UserManager<AppUser> _userManager;

        public SubProjectAuthorizationHandler(UserManager<AppUser> userManager, IDataccess appDBContext)
        {
            _userManager = userManager;
            _appDBContext = appDBContext;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Project resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (
                !context.User.IsInRole(Contants.AnyoneRole)
                )
            {
                return Task.CompletedTask;
            }

            switch (requirement.Name)
            {
                case Contants.ViewProjectName:
                case Contants.CreateTicketName:
                    if (((IRepository<ProjectUser>)_appDBContext).GetAll().Any(pu => pu.UserId == _userManager.GetUserId(context.User) && pu.ProjectId == resource.Id))
                    {
                        context.Succeed(requirement);
                    }
                    break;
            }

            return Task.CompletedTask;
        }
    }
    #endregion


    //dev and sub comment
    public class AverageCommentAuthorizationHandler
               : AuthorizationHandler<OperationAuthorizationRequirement, TicketComment>
    {
        UserManager<AppUser> _userManager;

        public AverageCommentAuthorizationHandler(UserManager<AppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   TicketComment resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (
                !context.User.IsInRole(Contants.DeveloperRole) &&
                !context.User.IsInRole(Contants.AnyoneRole)
                )
            {
                return Task.CompletedTask;
            }
            if (
                requirement.Name == Contants.EditCommentName ||
                requirement.Name == Contants.DeleteCommentName
                )
                if (resource.UserId == _userManager?.GetUserId(context.User))
                {
                    context.Succeed(requirement);
                }

            return Task.CompletedTask;
        }
    }

    // dev and sub attachment
    public class AverageAttachmentAuthorizationHandler
           : AuthorizationHandler<OperationAuthorizationRequirement, TicketAttachment>
    {
        UserManager<AppUser> _userManager;

        public AverageAttachmentAuthorizationHandler(UserManager<AppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   TicketAttachment resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (
                !context.User.IsInRole(Contants.DeveloperRole) &&
                !context.User.IsInRole(Contants.AnyoneRole)
                )
            {
                return Task.CompletedTask;
            }
            if (
                requirement.Name == Contants.EditAttachmentName ||
                requirement.Name == Contants.DeleteAttachmentName
                )
                if (resource.UserId == _userManager?.GetUserId(context.User))
                {
                    context.Succeed(requirement);
                }

            return Task.CompletedTask;
        }
    }


    #endregion average
}
