using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using BUGZ.LAYER_DOMAN;

namespace BUGZ.LAYER_DOMAN
{
    public class Contants
    {
        public const string AssignRoleName = "AssignRole";
        public const string ViewProjectName = "ViewProject";
        public const string CreateProjectName = "CreateProject";
        public const string EditProjectDetailsName = "EditProjectDetails";
        public const string AssignToProjectName = "AssignToProject";
        public const string ArchiveProjectName = "ArchiveProject";
        public const string ViewTicketDetailsName = "ViewTicketDetails";
        public const string CreateTicketName = "CreateTicket";
        public const string AssignToTicketName = "AssignToTicket";
        public const string EditTicketName = "EditTicket";
        public const string EditTicketPriorityName = "EditTicketPriority";
        public const string EditTicketStatusName = "EditTicketStatus";
        public const string AddCommentName = "AddComment";
        public const string AddAttachmentName = "AddAttachment";
        public const string EditCommentName = "EditComment";
        public const string DeleteCommentName = "DeleteComment";
        public const string EditAttachmentName = "EditAttachment";
        public const string DeleteAttachmentName = "DeleteAttachment";
        public const string ViewHistoryName = "ViewHistory";

        public const string AbminRole = "Admins";
        public const string ManagersRole = "Managers";
        public const string DeveloperRole = "Developers";
        public const string AnyoneRole = "Submitters";
    }

    public static class ContactOperations
    {
        public static OperationAuthorizationRequirement AssignRole = new OperationAuthorizationRequirement { Name = Contants.AssignRoleName }; 
        public static OperationAuthorizationRequirement ViewProject = new OperationAuthorizationRequirement { Name = Contants.ViewProjectName };
        public static OperationAuthorizationRequirement CreateProject = new OperationAuthorizationRequirement { Name = Contants.CreateProjectName };
        public static OperationAuthorizationRequirement EditProjectDetails = new OperationAuthorizationRequirement { Name = Contants.EditProjectDetailsName };
        public static OperationAuthorizationRequirement AssignToProject = new OperationAuthorizationRequirement { Name = Contants.AssignToProjectName };
        public static OperationAuthorizationRequirement ArchiveProject = new OperationAuthorizationRequirement { Name = Contants.ArchiveProjectName };
        public static OperationAuthorizationRequirement ViewTicketDetails = new OperationAuthorizationRequirement { Name = Contants.ViewTicketDetailsName };
        public static OperationAuthorizationRequirement CreateTicket = new OperationAuthorizationRequirement { Name = Contants.CreateTicketName };
        public static OperationAuthorizationRequirement AssignToTicket = new OperationAuthorizationRequirement { Name = Contants.AssignToTicketName };
        public static OperationAuthorizationRequirement EditTicket = new OperationAuthorizationRequirement { Name = Contants.EditTicketName };
        public static OperationAuthorizationRequirement EditTicketPriority = new OperationAuthorizationRequirement { Name = Contants.EditTicketPriorityName };
        public static OperationAuthorizationRequirement EditTicketStatus = new OperationAuthorizationRequirement { Name = Contants.EditTicketStatusName };
        public static OperationAuthorizationRequirement AddComment = new OperationAuthorizationRequirement { Name = Contants.AddCommentName };
        public static OperationAuthorizationRequirement AddAttachment = new OperationAuthorizationRequirement { Name = Contants.AddAttachmentName };
        public static OperationAuthorizationRequirement EditComment = new OperationAuthorizationRequirement { Name = Contants.EditCommentName };
        public static OperationAuthorizationRequirement DeleteComment = new OperationAuthorizationRequirement { Name = Contants.DeleteCommentName };
        public static OperationAuthorizationRequirement EditAttachment = new OperationAuthorizationRequirement { Name = Contants.EditAttachmentName };
        public static OperationAuthorizationRequirement DeleteAttachment = new OperationAuthorizationRequirement { Name = Contants.DeleteAttachmentName };
        public static OperationAuthorizationRequirement ViewHistory = new OperationAuthorizationRequirement { Name = Contants.ViewHistoryName };

    }
}
