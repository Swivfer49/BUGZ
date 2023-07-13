namespace BUGZ.LAYER_DOMAN
{
    public class TicketHistory
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string Property { get; set; }
        public string Old { get; set; }
        public string New { get; set; }
        public DateTime Changed { get; set; }
        public string UserId { get; set; }
    }
}
