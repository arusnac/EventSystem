namespace EventSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Attendee { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Qr { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int EventId { get; set; }
       // public Event currEvent { get; }
    }
}
