namespace BUGZ.LAYER_DOMAN
{
    public class TicketAttachment
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string UserId { get; set; }
        public string Url { get; set; }
    }
}
