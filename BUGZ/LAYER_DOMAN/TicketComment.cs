namespace BUGZ.LAYER_DOMAN
{
    public class TicketComment
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public Guid TicketId { get; set; }
        public string UserId { get; set; }
    }
}
