using BUGZ.LAYER_DOMAN;

namespace BUGZ.LAYER_DATACCESS
{
    public interface IDataccess 
    :   IRepository<AppUser>,
        IRepository<Project>,
        IRepository<ProjectUser>,
        IRepository<Ticket>,
        IRepository<TicketAttachment>,
        IRepository<TicketComment>,
        IRepository<TicketHistory>,
        IRepository<TicketNotification>,
        IRepository<TicketPriority>,
        IRepository<TicketStatus>,
        IRepository<TicketType>
    {

    }
}
