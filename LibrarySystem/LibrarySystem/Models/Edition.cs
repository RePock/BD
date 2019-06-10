using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Edition
    {
        [Key]
        [ForeignKey("Product")]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public TypeOfEdition TypeOfEdition { get; set; }
    }
}