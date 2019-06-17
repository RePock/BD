using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Issue
    {
        public int Id { get; set; }
        
        public DateTime DateOfIssue { get; set; }
        
        public DateTime DateOfExpiry { get; set; }
        
        public Product Product { get; set; }
        
        public Ticket Ticket { get; set; }
        
        public bool IsReturned { get; set; }
        
        public int LibraryId { get; set; }
        
        public Library Library { get; set; }
        
        public ICollection<LibraryWorker> LibraryWorker { get; set; }

        public Issue()
        {
            LibraryWorker = new List<LibraryWorker>();
        }
    }
}