namespace LibrarySystem.Models
{
    public class LibraryWorker
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int LibraryId { get; set; }
        
        public Library Library { get; set; }
    }
}