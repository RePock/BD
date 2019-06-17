using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace LibrarySystem.Models.Repository
{
    public class LibraryContextRepository
    {
        public LibraryContextRepository()
        {
        }

        public Task<IEnumerable<Schoolchild>> GetSchoolchildByClass(int numberOfClass)
        {
            var result = new List<Schoolchild>();
            using (var libraryContext = new LibraryContext())
            {
                result = libraryContext.Schoolchilds.Where(x => x.Class == numberOfClass).ToList();
            }

            return Task.FromResult<IEnumerable<Schoolchild>>(result);
        }

        public Task<IEnumerable<Worker>> GetWorkerByWorkPlace(string workPlace)
        {
            var result = new List<Worker>();
            using (var libraryContext = new LibraryContext())
            {
                result = libraryContext.Workers.Where(x => x.WorkPlace == workPlace).ToList();
            }

            return Task.FromResult<IEnumerable<Worker>>(result);
        }

        public Task<IEnumerable<Teacher>> GetTeacherByUniversity(string university)
        {
            var result = new List<Teacher>();
            using (var libraryContext = new LibraryContext())
            {
                result = libraryContext.Teachers.Where(x => x.University == university).ToList();
            }

            return Task.FromResult<IEnumerable<Teacher>>(result);
        }


        public Task<Pensioner> GetPensionerByNumberOfPensionDocument(int number)
        {
            var result = new Pensioner();
            using (var libraryContext = new LibraryContext())
            {
                result = libraryContext.Pensioners.FirstOrDefault(x => x.NumberOfPensionDocument == number);
            }

            return Task.FromResult(result);
        }


        public Task<IEnumerable<Student>> GetStudentByUniversity(string university)
        {
            var result = new List<Student>();
            using (var libraryContext = new LibraryContext())
            {
                result = libraryContext.Students.Where(x => x.University == university).ToList();
            }

            return Task.FromResult<IEnumerable<Student>>(result);
        }


        public Task<IEnumerable<Ticket>> GetPeopleByReadingProduct(string name)
        {
            var result = new List<Ticket>();
            using (var libraryContext = new LibraryContext())
            {
                result = QueryableExtensions
                    .Include(QueryableExtensions.Include(libraryContext.Issues, x => x.Ticket), y => y.Product)
                    .Where(x => x.Product.Name == name && x.IsReturned == false).Select(x => x.Ticket)
                    .ToList();
            }

            return Task.FromResult<IEnumerable<Ticket>>(result);
        }

        public Task<IEnumerable<Ticket>> GetPeopleByReadingProductOnTime(DateTime start, DateTime finish)
        {
            var result = new List<Ticket>();
            using (var libraryContext = new LibraryContext())
            {
                result = QueryableExtensions
                    .Include(QueryableExtensions
                        .Include(libraryContext.Issues, (x => x.Ticket)), y => y.Product)
                    .Where(x => x.DateOfIssue > start && x.DateOfIssue < finish).Select(x=>x.Ticket).ToList();
            }

            return Task.FromResult<IEnumerable<Ticket>>(result);
        }

        public Task<Product> GetMostPopularProduct()
        {
            var countIssues = new Dictionary<Product, int>();
            using (var libraryContext = new LibraryContext())
            {
                var mergedTable = QueryableExtensions.Include(
                    QueryableExtensions.Include(libraryContext.Issues, (x => x.Ticket)),
                    y => y.Product);

                foreach (var product in libraryContext.Products)
                {
                    countIssues.Add(product, mergedTable.Count(x => x.Product.Name == product.Name));
                }
            }

            return Task.FromResult(countIssues.OrderByDescending(x => x.Value).First().Key);
        }


        public Task<IEnumerable<LibraryWorker>> GetWorkerLibraryByLibrary(int id)
        {
            var result = new List<LibraryWorker>();

            using (var libraryContext = new LibraryContext())
            {
                result = QueryableExtensions.Include(libraryContext.Libraries, x => x.LibraryWorker).Where(x=>x.Id==id).Select(x=>x.LibraryWorker).First().ToList();
            }

            return Task.FromResult<IEnumerable<LibraryWorker>>(result);
        }

        public Task<IEnumerable<Ticket>> GetOverdueReader()
        {
            var result = new List<Ticket>();

            using (var libraryContext = new LibraryContext())
            {
                result = QueryableExtensions.Include(libraryContext.Issues, x => x.Ticket)
                    .Where(x => x.IsReturned == false && x.DateOfExpiry < DateTime.Now).Select(x => x.Ticket).ToList();
            }

            return Task.FromResult<IEnumerable<Ticket>>(result);
        }


        public Task<IEnumerable<Product>> GetProductByLocation(int numberOfShelving)
        {
            var result = new List<Product>();
            using (var libraryContext = new LibraryContext())
            {
                result = QueryableExtensions.Include(libraryContext.Products, x => x.Location)
                    .Where(x => x.Location.NumberOfShelving == numberOfShelving).ToList();
            }

            return Task.FromResult<IEnumerable<Product>>(result);
        }

        public Task<IEnumerable<Ticket>> GetPeopleServicedByLibraryWorker(int libraryWorkerId)
        {
            var result = new List<Ticket>();
            using (var libraryContext = new LibraryContext())
            {
                result = QueryableExtensions
                    .Include(QueryableExtensions.Include(libraryContext.Issues, x => x.Ticket), y => y.LibraryWorker)
                    .Where(x => x.LibraryWorker.FirstOrDefault(y => y.Id == libraryWorkerId) != null)
                    .Select(x => x.Ticket).ToList();
            }

            return Task.FromResult<IEnumerable<Ticket>>(result);
        }


        public Task<IEnumerable<Product>> GetProductByAuthor(int authorId)
        {
            var result = new List<Product>();

            using (var libraryContext = new LibraryContext())
            {
                var qwer = QueryableExtensions.Include(libraryContext.Products, x => x.Author);
                result = QueryableExtensions.Include(libraryContext.Products, x => x.Author)
                    .Where(x => x.Author.Id == authorId).ToList();
            }

            return Task.FromResult<IEnumerable<Product>>(result);
        }


        public Task<int> GetCountPeopleServicedByLibraryWorker(DateTime start, DateTime finish)
        {
            var sum = 0;

            using (var libraryContext = new LibraryContext())
            {
                sum = QueryableExtensions
                    .Include(QueryableExtensions.Include(libraryContext.Issues, x => x.Ticket), y => y.LibraryWorker)
                    .Count(x => x.DateOfIssue > start && x.DateOfIssue < finish);
            }

            return Task.FromResult<int>(sum);
        }


        public Task<IEnumerable<Ticket>> GetAllTicket()
        {
            var result = new List<Ticket>();

            using (var libraryContext = new LibraryContext())
            {
                result = libraryContext.Tickets.OrderBy(x=>x.Id).ToList();
            }
            
            return Task.FromResult<IEnumerable<Ticket>>(result);
        }
        
        public Task<IEnumerable<LibraryWorker>> GetAllLibraryWorker()
        {
            var result = new List<LibraryWorker>();

            using (var libraryContext = new LibraryContext())
            {
                result = libraryContext.LibraryWorkers.OrderBy(x=>x.Id).ToList();
            }
            
            return Task.FromResult<IEnumerable<LibraryWorker>>(result);
        }

        public void CreateTicket(string firstName, string secondName,int readersId)
        {
            var newReader = new Ticket(){FirstName = firstName,LastName = secondName,ReadersId = readersId};
            using (var libraryContext = new LibraryContext())
            {
                libraryContext.Tickets.Add(newReader);
                libraryContext.SaveChanges();
            }
        }
        
        public void DeleteTicket(int id)
        {
            using (var libraryContext = new LibraryContext())
            {
                var ticket = libraryContext.Tickets.FirstOrDefault(x => x.Id == id);
                if (ticket != null)
                {
                    libraryContext.Remove(ticket);
                    libraryContext.Entry(ticket).State = EntityState.Deleted;
                    libraryContext.SaveChanges();
                }
            }
        }

        public void ChangeTicket(int id,string fistName,string lastName,int? readersId)
        {
            using (var libraryContext = new LibraryContext())
            {
                var ticket = libraryContext.Tickets.FirstOrDefault(x => x.Id == id);
                if (ticket != null)
                {
                    ticket.FirstName = fistName;
                    ticket.LastName = lastName;
                    ticket.ReadersId = readersId;
                    libraryContext.Entry(ticket).State = EntityState.Modified;
                    libraryContext.SaveChanges();
                }
            }
        }
    }
}