using BUGZ.LAYER_DOMAN;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BUGZ.LAYER_DATACCESS
{
    public class AppDBContext : IdentityDbContext<AppUser>, IDataccess
    {
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketAttachment> TicketAttachments { get; set; }
        public virtual DbSet<TicketComment> TicketComments { get; set; }
        public virtual DbSet<TicketHistory> TicketHistory { get; set; }
        public virtual DbSet<TicketNotification> TicketNotifications { get; set; }
        public virtual DbSet<TicketPriority> TicketPriority { get; set; }
        public virtual DbSet<TicketStatus> TicketStatuses { get; set; }
        public virtual DbSet<TicketType> TicketTypes { get; set; }
        void IRepository<AppUser>.Delete(AppUser item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Project>.Delete(Project item)
        {
            throw new NotImplementedException();
        }

        void IRepository<ProjectUser>.Delete(ProjectUser item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Ticket>.Delete(Ticket item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketAttachment>.Delete(TicketAttachment item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketComment>.Delete(TicketComment item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketHistory>.Delete(TicketHistory item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketNotification>.Delete(TicketNotification item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketPriority>.Delete(TicketPriority item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketStatus>.Delete(TicketStatus item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketType>.Delete(TicketType item)
        {
            throw new NotImplementedException();
        }

        AppUser IRepository<AppUser>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        Project IRepository<Project>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        ProjectUser IRepository<ProjectUser>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        Ticket IRepository<Ticket>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        TicketAttachment IRepository<TicketAttachment>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        TicketComment IRepository<TicketComment>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        TicketHistory IRepository<TicketHistory>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        TicketNotification IRepository<TicketNotification>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        TicketPriority IRepository<TicketPriority>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        TicketStatus IRepository<TicketStatus>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        TicketType IRepository<TicketType>.Get(params object[] keys)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AppUser> IRepository<AppUser>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Project> IRepository<Project>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<ProjectUser> IRepository<ProjectUser>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Ticket> IRepository<Ticket>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TicketAttachment> IRepository<TicketAttachment>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TicketComment> IRepository<TicketComment>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TicketHistory> IRepository<TicketHistory>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TicketNotification> IRepository<TicketNotification>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TicketPriority> IRepository<TicketPriority>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TicketStatus> IRepository<TicketStatus>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TicketType> IRepository<TicketType>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepository<AppUser>.Insert(AppUser item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Project>.Insert(Project item)
        {
            throw new NotImplementedException();
        }

        void IRepository<ProjectUser>.Insert(ProjectUser item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Ticket>.Insert(Ticket item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketAttachment>.Insert(TicketAttachment item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketComment>.Insert(TicketComment item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketHistory>.Insert(TicketHistory item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketNotification>.Insert(TicketNotification item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketPriority>.Insert(TicketPriority item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketStatus>.Insert(TicketStatus item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketType>.Insert(TicketType item)
        {
            throw new NotImplementedException();
        }

        void IRepository<AppUser>.Update(AppUser item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Project>.Update(Project item)
        {
            throw new NotImplementedException();
        }

        void IRepository<ProjectUser>.Update(ProjectUser item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Ticket>.Update(Ticket item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketAttachment>.Update(TicketAttachment item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketComment>.Update(TicketComment item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketHistory>.Update(TicketHistory item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketNotification>.Update(TicketNotification item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketPriority>.Update(TicketPriority item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketStatus>.Update(TicketStatus item)
        {
            throw new NotImplementedException();
        }

        void IRepository<TicketType>.Update(TicketType item)
        {
            throw new NotImplementedException();
        }
    }
}
