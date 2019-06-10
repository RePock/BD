using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Limit
    {
        [Key]
        [ForeignKey("Product")]
        public int Id { get; set; }
        
        public string LimitValue { get; set; }
    }
}