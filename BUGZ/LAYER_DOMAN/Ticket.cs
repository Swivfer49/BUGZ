namespace BUGZ.LAYER_DOMAN
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TicketTypeId { get; set; }
        public Guid TicketPriorityId { get; set; }
        public Guid TicketStatusId { get; set; }
        public string OwnerUserId { get; set; }
        public string AssignedUserId { get; set; }
    }
}
