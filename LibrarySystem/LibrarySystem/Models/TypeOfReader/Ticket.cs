namespace LibrarySystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public int? ReadersId { get; set; }

        public Readers Readers { get; set; }
    }
}