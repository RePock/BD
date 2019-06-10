

using System.Data.Entity;

namespace LibrarySystem.Models
{
    public class LibraryContext : DbContext
    {
        
        public DbSet<Pensioner> Pensioners { get; set; }
        
        public DbSet<Schoolchild> Schoolchilds { get; set; }
        
        public DbSet<Scientist> Scientists { get; set; }
        
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Teacher> Teachers { get; set; }
        
        public DbSet<Ticket> Tickets { get; set; }
        
        public DbSet<Worker> Workers { get; set; }
        
        public DbSet<Author> Authors { get; set; }
        
        public DbSet<Edition> Editions { get; set; }
        
        public DbSet<Issue> Issues { get; set; }
        
        public DbSet<Library> Libraries { get; set; }
        
        public DbSet<LibraryFund> LibraryFunds { get; set; }
        
        public DbSet<LibraryWorker> LibraryWorkers { get; set; }
        
        public DbSet<Limit> Limits { get; set; }
        
        public DbSet<Location> Locations { get; set; }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Readers> Readers { get; set; }

        public LibraryContext() : base("Default"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
        
    }
}