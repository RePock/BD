using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Author
    {
        [Key]
        [ForeignKey("Product")]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}