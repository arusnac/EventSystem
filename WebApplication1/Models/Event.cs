namespace EventSystem.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int TicketsAvailable { get; set; }
        public float Price { get; set; }
    }
}
