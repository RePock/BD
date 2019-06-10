using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

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
            using (var libraryContex = new LibraryContext())
            {
                result = libraryContex.Schoolchilds.Where(x => x.Class == numberOfClass).ToList();
            }

            return Task.FromResult<IEnumerable<Schoolchild>>(result);
        }

        public Task<IEnumerable<Worker>> GetWorkerByWorkPlace(string workPlace)
        {
            var result = new List<Worker>();
            using (var libraryContex = new LibraryContext())
            {
                result = libraryContex.Workers.Where(x => x.WorkPlace == workPlace).ToList();
            }

            return Task.FromResult<IEnumerable<Worker>>(result);
        }

        public Task<IEnumerable<Teacher>> GetTeacherByUniversity(string university)
        {
            var result = new List<Teacher>();
            using (var libraryContex = new LibraryContext())
            {
                result = libraryContex.Teachers.Where(x => x.University == university).ToList();
            }

            return Task.FromResult<IEnumerable<Teacher>>(result);
        }


        public Task<Pensioner> GetPensionerByNumberOfPensionDocument(int number)
        {
            var result = new Pensioner();
            using (var libraryContex = new LibraryContext())
            {
                result = libraryContex.Pensioners.FirstOrDefault(x => x.NumberOfPensionDocument == number);
            }

            return Task.FromResult(result);
        }


        public Task<IEnumerable<Student>> GetStudentByUniversity(string university)
        {
            var result = new List<Student>();
            using (var libraryContex = new LibraryContext())
            {
                result = libraryContex.Students.Where(x => x.University == university).ToList();
            }

            return Task.FromResult<IEnumerable<Student>>(result);
        }


        public Task<IEnumerable<string>> GetPeopleByReadingProduct(string name)
        {
            var result = new List<string>();
            using (var libraryContex = new LibraryContext())
            {
                result = (libraryContex.Issues.Include(x => x.Ticket)).Include(x => x.Product)
                    .Where(x => x.Product.Name == name && x.IsReturned == false).Select(x => x.Ticket.FirstName)
                    .ToList();
            }

            return Task.FromResult<IEnumerable<string>>(result);
        }

        public Task<Dictionary<string, string>> GetPeopleByReadingProductOnTime(DateTime start, DateTime finish)
        {
            var result = new List<Issue>();
            using (var libraryContex = new LibraryContext())
            {
                result = (libraryContex.Issues.Include(x => x.Ticket)).Include(x => x.Product)
                    .Where(x => x.DateOfIssue > start && x.DateOfIssue < finish).ToList();
            }

            var resultDict = new Dictionary<string, string>();
            foreach (var issue in result)
            {
                if (resultDict.ContainsKey(issue.Ticket.FirstName))
                {
                    continue;
                }

                resultDict.Add(issue.Ticket.FirstName, issue.Product.Name);
            }

            return Task.FromResult(resultDict);
        }

        public Task<Product> GetMostPopularProduct()
        {
            var countIssues = new Dictionary<Product, int>();
            using (var libraryContex = new LibraryContext())
            {
                var mergedTable = (libraryContex.Issues.Include(x => x.Ticket)).Include(x => x.Product);

                foreach (var product in libraryContex.Products)
                {
                    countIssues.Add(product, mergedTable.Count(x => x.Product.Name == product.Name));
                }
            }

            return Task.FromResult(countIssues.OrderByDescending(x => x.Value).First().Key);
        }


        public Task<IEnumerable<LibraryWorker>> GetWorkerLibraryByLibrary(int id)
        {
            var result = new List<LibraryWorker>();

            using (var libraryContex = new LibraryContext())
            {
                result = libraryContex.Libraries.Include(x => x.LibraryWorker).FirstOrDefault(x => x.Id == id)
                    ?.LibraryWorker.ToList();
            }

            return Task.FromResult<IEnumerable<LibraryWorker>>(result);
        }

        public Task<IEnumerable<Ticket>> GetOverdueReader()
        {
            var result = new List<Ticket>();

            using (var libraryContex = new LibraryContext())
            {
                result = libraryContex.Issues.Include(x => x.Ticket)
                    .Where(x => x.IsReturned == false && x.DateOfExpiry < DateTime.Now).Select(x => x.Ticket).ToList();
            }

            return Task.FromResult<IEnumerable<Ticket>>(result);
        }
        
    }
}