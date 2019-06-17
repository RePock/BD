using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Readers
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<Pensioner> Pensioners { get; set; }
        
        public ICollection<Schoolchild> Schoolchilds { get; set; }
        
        public ICollection<Scientist> Scientists { get; set; }
        
        public ICollection<Student> Students { get; set; }
        
        public ICollection<Teacher> Teachers { get; set; }
        
        public ICollection<Worker> Workers { get; set; }
        
        public int LibraryId { get; set; }
    
        public Library Library { get; set; }

        public Readers()
        {
            Pensioners = new List<Pensioner>();
            Schoolchilds = new List<Schoolchild>();
            Scientists = new List<Scientist>();
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Workers = new List<Worker>();
        }
    }
}