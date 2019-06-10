namespace LibrarySystem.Models
{
    public class Student: Ticket
    {
        public string Faculty { get; set; }

        public int Course { get; set; }

        public string University { get; set; }
    }
}