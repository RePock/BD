using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Location
    {
        [Key]
        [ForeignKey("Product")]
        public int Id { get; set;}
        
        public int NumberOfHall { get; set; }
        
        public int NumberOfShelving { get; set; }
        
        public int NumberOfBench { get; set; }
    }
}