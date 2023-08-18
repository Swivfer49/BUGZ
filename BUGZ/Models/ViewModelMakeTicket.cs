using BUGZ.LAYER_DOMAN;

namespace BUGZ.Models
{
    public class ViewModelMakeTicket
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TypeId { get; set; }
        public Guid ProirityId { get; set; }

        public IEnumerable<TicketType> ticketTypes { get; set; }
        public IEnumerable<TicketPriority> ticketPriority { get; set; }
        public IEnumerable<Project> projects { get; set; }

    }
}
