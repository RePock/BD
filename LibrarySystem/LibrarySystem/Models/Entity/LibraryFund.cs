using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class LibraryFund
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string City { get; set; }
        
        public ICollection<Library> Libraries { get; set; }

        public LibraryFund()
        {
            Libraries = new List<Library>();
        }
    }
}