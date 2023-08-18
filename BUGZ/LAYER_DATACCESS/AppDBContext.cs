using BUGZ.LAYER_DOMAN;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BUGZ.LAYER_DATACCESS
{
    public class AppDBContext : IdentityDbContext<AppUser>, IDataccess
    {

        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions) : base(dbContextOptions) { }

        #region dbset

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

        #endregion

        #region Delete
        void IRepository<AppUser>.Delete(AppUser item)
        {
            AppUsers.Remove(item);
            this.SaveChanges();
        }

        void IRepository<Project>.Delete(Project item)
        {
            Projects.Remove(item);
            this.SaveChanges();
        }

        void IRepository<ProjectUser>.Delete(ProjectUser item)
        {
            ProjectUsers.Remove(item);
            this.SaveChanges();
        }

        void IRepository<Ticket>.Delete(Ticket item)
        {
            Tickets.Remove(item);
            this.SaveChanges();
        }

        void IRepository<TicketAttachment>.Delete(TicketAttachment item)
        {
            TicketAttachments.Remove(item);
            this.SaveChanges();
        }

        void IRepository<TicketComment>.Delete(TicketComment item)
        {
            TicketComments.Remove(item);
            this.SaveChanges();
        }

        void IRepository<TicketHistory>.Delete(TicketHistory item)
        {
            TicketHistory.Remove(item);
            this.SaveChanges();
        }

        void IRepository<TicketNotification>.Delete(TicketNotification item)
        {
            TicketNotifications.Remove(item);
            this.SaveChanges();
        }

        void IRepository<TicketPriority>.Delete(TicketPriority item)
        {
            TicketPriority.Remove(item);
            this.SaveChanges();
        }

        void IRepository<TicketStatus>.Delete(TicketStatus item)
        {
            TicketStatuses.Remove(item);
            this.SaveChanges();
        }

        void IRepository<TicketType>.Delete(TicketType item)
        {
            TicketTypes.Remove(item);
            this.SaveChanges();
        }

        #endregion

        #region Get

        AppUser IRepository<AppUser>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is string)) throw new ArgumentException("dude why is this thing not a string?");
            AppUser? result = AppUsers.FirstOrDefault(u=>u.Id == (string)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<AppUser>(JsonConvert.SerializeObject(result))!;
        }

        Project IRepository<Project>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            Project? result = Projects.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<Project>(JsonConvert.SerializeObject(result))!;
        }

        ProjectUser IRepository<ProjectUser>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            ProjectUser? result = ProjectUsers.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<ProjectUser>(JsonConvert.SerializeObject(result))!;
        }

        Ticket IRepository<Ticket>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            Ticket? result = Tickets.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<Ticket>(JsonConvert.SerializeObject(result))!;
        }

        TicketAttachment IRepository<TicketAttachment>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            TicketAttachment? result = TicketAttachments.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<TicketAttachment>(JsonConvert.SerializeObject(result))!;
        }

        TicketComment IRepository<TicketComment>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            TicketComment? result = TicketComments.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<TicketComment>(JsonConvert.SerializeObject(result))!;
        }

        TicketHistory IRepository<TicketHistory>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            TicketHistory? result = TicketHistory.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<TicketHistory>(JsonConvert.SerializeObject(result))!;
        }

        TicketNotification IRepository<TicketNotification>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            TicketNotification? result = TicketNotifications.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<TicketNotification>(JsonConvert.SerializeObject(result))!;
        }

        TicketPriority IRepository<TicketPriority>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            TicketPriority? result = TicketPriority.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<TicketPriority>(JsonConvert.SerializeObject(result))!;
        }

        TicketStatus IRepository<TicketStatus>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            TicketStatus? result = TicketStatuses.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<TicketStatus>(JsonConvert.SerializeObject(result))!;
        }

        TicketType IRepository<TicketType>.Get(params object[] keys)
        {
            if (keys.Length < 1) throw new ArgumentException("bro where is the key?");
            if (!(keys[0] is Guid)) throw new ArgumentException("dude why is this thing not a (whatever a GUID is)?");
            TicketType? result = TicketTypes.FirstOrDefault(u => u.Id == (Guid)keys[0]);
            if (result == null) throw new ArgumentException("these aren't the appusers that you are looking for");

            return JsonConvert.DeserializeObject<TicketType>(JsonConvert.SerializeObject(result))!;
        }

        #endregion

        #region GetAll

        IEnumerable<AppUser> IRepository<AppUser>.GetAll()
        {
            return AppUsers.ToArray().Select(u =>
            JsonConvert.DeserializeObject<AppUser>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<Project> IRepository<Project>.GetAll()
        {
            return Projects.ToArray().Select(u =>
            JsonConvert.DeserializeObject<Project>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<ProjectUser> IRepository<ProjectUser>.GetAll()
        {
            return ProjectUsers.ToArray().Select(u =>
            JsonConvert.DeserializeObject<ProjectUser>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<Ticket> IRepository<Ticket>.GetAll()
        {
            return Tickets.ToArray().Select(u =>
            JsonConvert.DeserializeObject<Ticket>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<TicketAttachment> IRepository<TicketAttachment>.GetAll()
        {
            return TicketAttachments.ToArray().Select(u =>
            JsonConvert.DeserializeObject<TicketAttachment>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<TicketComment> IRepository<TicketComment>.GetAll()
        {
            return TicketComments.ToArray().Select(u =>
            JsonConvert.DeserializeObject<TicketComment>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<TicketHistory> IRepository<TicketHistory>.GetAll()
        {
            return TicketHistory.ToArray().Select(u =>
            JsonConvert.DeserializeObject<TicketHistory>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<TicketNotification> IRepository<TicketNotification>.GetAll()
        {
            return TicketNotifications.ToArray().Select(u =>
            JsonConvert.DeserializeObject<TicketNotification>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<TicketPriority> IRepository<TicketPriority>.GetAll()
        {
            return TicketPriority.ToArray().Select(u =>
            JsonConvert.DeserializeObject<TicketPriority>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<TicketStatus> IRepository<TicketStatus>.GetAll()
        {
            return TicketStatuses.ToArray().Select(u =>
            JsonConvert.DeserializeObject<TicketStatus>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        IEnumerable<TicketType> IRepository<TicketType>.GetAll()
        {
            return TicketTypes.ToArray().Select(u =>
            JsonConvert.DeserializeObject<TicketType>(
                JsonConvert.SerializeObject(u)
                )!
            );
        }

        #endregion

        #region Insert

        void IRepository<AppUser>.Insert(AppUser item)
        {
            AppUsers.Add(item);
            SaveChanges();
        }

        void IRepository<Project>.Insert(Project item)
        {
            Projects.Add(item);
            SaveChanges();
        }

        void IRepository<ProjectUser>.Insert(ProjectUser item)
        {
            ProjectUsers.Add(item);
            SaveChanges();
        }

        void IRepository<Ticket>.Insert(Ticket item)
        {
            Tickets.Add(item);
            SaveChanges();
        }

        void IRepository<TicketAttachment>.Insert(TicketAttachment item)
        {
            TicketAttachments.Add(item);
            SaveChanges();
        }

        void IRepository<TicketComment>.Insert(TicketComment item)
        {
            TicketComments.Add(item);
            SaveChanges();
        }

        void IRepository<TicketHistory>.Insert(TicketHistory item)
        {
            TicketHistory.Add(item);
            SaveChanges();
        }

        void IRepository<TicketNotification>.Insert(TicketNotification item)
        {
            TicketNotifications.Add(item);
            SaveChanges();
        }

        void IRepository<TicketPriority>.Insert(TicketPriority item)
        {
            TicketPriority.Add(item);
            SaveChanges();
        }

        void IRepository<TicketStatus>.Insert(TicketStatus item)
        {
            TicketStatuses.Add(item);
            SaveChanges();
        }

        void IRepository<TicketType>.Insert(TicketType item)
        {
            TicketTypes.Add(item);
            SaveChanges();
        }

        #endregion

        #region Update

        void IRepository<AppUser>.Update(AppUser item)
        {
            AppUser theRealOne = AppUsers.FirstOrDefault(u=>u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.UserName = item.UserName;
            theRealOne.NormalizedUserName = item.NormalizedUserName;
            theRealOne.Email = item.Email;
            theRealOne.NormalizedEmail = item.NormalizedEmail;
            theRealOne.EmailConfirmed = item.EmailConfirmed;
            theRealOne.PasswordHash = item.PasswordHash;
            theRealOne.SecurityStamp = item.SecurityStamp;
            theRealOne.ConcurrencyStamp = item.ConcurrencyStamp;
            theRealOne.PhoneNumber = item.PhoneNumber;
            theRealOne.PhoneNumberConfirmed = item.PhoneNumberConfirmed;
            theRealOne.TwoFactorEnabled = item.TwoFactorEnabled;
            theRealOne.LockoutEnd = item.LockoutEnd;
            theRealOne.LockoutEnabled = item.LockoutEnabled;
            theRealOne.AccessFailedCount = item.AccessFailedCount;
            SaveChanges();
        }

        void IRepository<Project>.Update(Project item)
        {
            Project theRealOne = Projects.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.Name = item.Name;
            SaveChanges();
        }

        void IRepository<ProjectUser>.Update(ProjectUser item)
        {
            ProjectUser theRealOne = ProjectUsers.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.ProjectId = item.ProjectId;
            theRealOne.UserId = item.UserId;
            SaveChanges();
        }

        void IRepository<Ticket>.Update(Ticket item)
        {
            Ticket theRealOne = Tickets.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.Title = item.Title;
            theRealOne.Description = item.Description;
            theRealOne.Created = item.Created;
            theRealOne.Updated = item.Updated;
            theRealOne.ProjectId = item.ProjectId;
            theRealOne.TicketTypeId = item.TicketTypeId;
            theRealOne.TicketPriorityId = item.TicketPriorityId;
            theRealOne.TicketStatusId = item.TicketStatusId;
            theRealOne.OwnerUserId = item.OwnerUserId;
            theRealOne.AssignedUserId = item.AssignedUserId;
            SaveChanges();
        }

        void IRepository<TicketAttachment>.Update(TicketAttachment item)
        {
            TicketAttachment theRealOne = TicketAttachments.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.TicketId = item.TicketId;
            theRealOne.FilePath = item.FilePath;
            theRealOne.Description = item.Description;
            theRealOne.Created = item.Created;
            theRealOne.UserId = item.UserId;
            theRealOne.Url = item.Url;
            SaveChanges();
        }

        void IRepository<TicketComment>.Update(TicketComment item)
        {
            TicketComment theRealOne = TicketComments.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.Comment = item.Comment;
            theRealOne.Created = item.Created;
            theRealOne.TicketId = item.TicketId;
            theRealOne.UserId = item.UserId;
            SaveChanges();
        }

        void IRepository<TicketHistory>.Update(TicketHistory item)
        {
            TicketHistory theRealOne = TicketHistory.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.TicketId = item.TicketId;
            theRealOne.Property = item.Property;
            theRealOne.Old = item.Old;
            theRealOne.New = item.New;
            theRealOne.Changed = item.Changed;
            theRealOne.UserId = item.UserId;
            SaveChanges();
        }

        void IRepository<TicketNotification>.Update(TicketNotification item)
        {
            TicketNotification theRealOne = TicketNotifications.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.TicketId = item.TicketId;
            theRealOne.UserId = item.UserId;
            SaveChanges();
        }

        void IRepository<TicketPriority>.Update(TicketPriority item)
        {
            TicketPriority theRealOne = TicketPriority.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.Name = item.Name;
            SaveChanges();
        }

        void IRepository<TicketStatus>.Update(TicketStatus item)
        {
            TicketStatus theRealOne = TicketStatuses.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.Name = item.Name;
            SaveChanges();
        }

        void IRepository<TicketType>.Update(TicketType item)
        {
            TicketType theRealOne = TicketTypes.FirstOrDefault(u => u.Id == item.Id);
            if (theRealOne == null) throw new ArgumentException("this item was never here");
            theRealOne.Name = item.Name;
            SaveChanges();
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Ticket>()
                .HasOne(t => t.AssignedUser)
                .WithMany(a => a.AssignedTickets)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
                
        }

        public Ticket GetFullTicket(Guid id)
        {
            Ticket Result = Tickets
                .Include(t => t.TicketType)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.Project)
                .FirstOrDefault(t=>t.Id == id);
            if (Result == null) throw new ArgumentException();
            return JsonConvert.DeserializeObject<Ticket>(JsonConvert.SerializeObject(Result))!;
        }

        public IEnumerable<Ticket> GetMyTickets(string userId)
        {
            IEnumerable<Ticket> Result = Tickets
                .Include(t => t.TicketType)
                .Include(t => t.TicketPriority)
                .Include(t => t.TicketStatus)
                .Include(t => t.Project)
                .Where(t=>t.OwnerUserId == userId || t.AssignedUserId == userId)
                .ToArray()
                .Select(u => JsonConvert.DeserializeObject<Ticket>(JsonConvert.SerializeObject(u))!); 
            return Result;
        }
    }
}
