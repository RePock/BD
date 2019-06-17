using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Library
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public ICollection<Readers> Readers { get; set; }

        public ICollection<Product> Products { get; set; }
        
        public ICollection<Issue> Issues { get; set; }

        public int? LibraryFundId { get; set; }
        
        public LibraryFund LibraryFund { get; set; }
        
        public ICollection<LibraryWorker> LibraryWorker { get; set; }

        public Library()
        {
            Readers = new List<Readers>();
            Products = new List<Product>();
            Issues = new List<Issue>();
            LibraryWorker = new List<LibraryWorker>();
        }
    }
}