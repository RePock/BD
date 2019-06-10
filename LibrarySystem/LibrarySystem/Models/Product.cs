using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Author Author { get; set; }
        
        public Edition Edition { get; set; }
        
        public TypeOfCategory TypeOfCategory { get; set; }
        
        public Location Location { get; set; }

        public Limit Limit { get; set; }
        
        public bool InStock { get; set; }
        
        public int LibraryId { get; set; }
        
        public Library Library { get; set; }
    }
}