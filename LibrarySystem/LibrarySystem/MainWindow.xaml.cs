using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Windows;
using LibrarySystem.Models;
using LibrarySystem.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace LibrarySystem
{
    public partial class MainWindow
    {
        private LibraryContextRepository _libraryContextRepository;

        public MainWindow()
        {
            _libraryContextRepository = new LibraryContextRepository();
            InitializeComponent();
            //InitDataBase();
        }

        public void InitDataBase()
        {
            using (var libraryContex = new LibraryContext())
            {
                var libraryFund = new LibraryFund()
                    {Name = "Goverment", City = "Novosibirs"};
                libraryContex.LibraryFunds.Add(libraryFund);

                var library1 = new Library()
                    {Name = "library1", LibraryFund = libraryFund};
                libraryContex.Libraries.Add(library1);

                var library2 = new Library()
                    {Name = "library2", LibraryFund = libraryFund};
                libraryContex.Libraries.Add(library2);

                var readers1 = new Readers()
                    {Name = "reader1", Library = library1};
                var readers2 = new Readers()
                    {Name = "reader2", Library = library2};

                var pensioner1 = new Pensioner()
                    {FirstName = "Alexandr", LastName = "Mordvinov", NumberOfPensionDocument = 1, Readers = readers1};
                libraryContex.Pensioners.Add(pensioner1);
                var pensioner2 = new Pensioner()
                    {FirstName = "Ilya", LastName = "Nikov", NumberOfPensionDocument = 2, Readers = readers1};
                libraryContex.Pensioners.Add(pensioner2);
                var pensioner3 = new Pensioner()
                    {FirstName = "Vasya", LastName = "Pupkin", NumberOfPensionDocument = 3, Readers = readers2};
                libraryContex.Pensioners.Add(pensioner3);
                var pensioner4 = new Pensioner()
                    {FirstName = "Oleg", LastName = "Ivanov", NumberOfPensionDocument = 4, Readers = readers2};
                libraryContex.Pensioners.Add(pensioner4);


                var schoolchild1 = new Schoolchild()
                    {FirstName = "Alexey", LastName = "Alexndrov", Class = 4, School = "32", Readers = readers1};
                libraryContex.Schoolchilds.Add(schoolchild1);
                var schoolchild2 = new Schoolchild()
                    {FirstName = "Dmitriy", LastName = "Vick", Class = 7, School = "22", Readers = readers1};
                libraryContex.Schoolchilds.Add(schoolchild2);
                var schoolchild3 = new Schoolchild()
                    {FirstName = "Kostya", LastName = "Seleznev", Class = 4, School = "88", Readers = readers2};
                libraryContex.Schoolchilds.Add(schoolchild3);


                var scientist1 = new Scientist()
                    {Organization = "Nsu", Theme = "Biology", FirstName = "Max", LastName = "Max", Readers = readers1};
                libraryContex.Scientists.Add(scientist1);
                var scientist2 = new Scientist()
                {
                    Organization = "Nsu", Theme = "Chemistry", FirstName = "Dmitriy", LastName = "Dmitriy",
                    Readers = readers2
                };
                libraryContex.Scientists.Add(scientist2);
                var scientist3 = new Scientist()
                {
                    Organization = "Nsu", Theme = "Math", FirstName = "Sergei", LastName = "Sergei", Readers = readers2
                };
                libraryContex.Scientists.Add(scientist3);

                var student1 = new Student()
                {
                    Faculty = "FIT", Course = 1, University = "Nsu", FirstName = "Nadya", LastName = "Nadya",
                    Readers = readers1
                };
                libraryContex.Students.Add(student1);
                var student2 = new Student()
                {
                    Faculty = "GGF", Course = 2, University = "Nsu", FirstName = "Alena", LastName = "Alena",
                    Readers = readers1
                };
                libraryContex.Students.Add(student2);
                var student3 = new Student()
                {
                    Faculty = "FF", Course = 3, University = "Nsu", FirstName = "John", LastName = "John",
                    Readers = readers2
                };
                libraryContex.Students.Add(student3);

                var teacher1 = new Teacher()
                {
                    Subject = "Math", University = "MSu", FirstName = "Tatyana", LastName = "Tatyana",
                    Readers = readers1
                };
                libraryContex.Teachers.Add(teacher1);
                var teacher2 = new Teacher()
                {
                    Subject = "Chemistry", University = "TSU", FirstName = "Katy", LastName = "Katy", Readers = readers2
                };
                libraryContex.Teachers.Add(teacher2);
                var teacher3 = new Teacher()
                {
                    Subject = "Biology", University = "NSU", FirstName = "Vincent", LastName = "Vincent",
                    Readers = readers2
                };
                libraryContex.Teachers.Add(teacher3);

                var worker1 = new Worker()
                    {WorkPlace = "Zavod", FirstName = "Evgeniy", LastName = "Evgeniy", Readers = readers1};
                libraryContex.Workers.Add(worker1);
                var worker2 = new Worker()
                    {WorkPlace = "Galera", FirstName = "Erohin", LastName = "Erohin", Readers = readers1};
                libraryContex.Workers.Add(worker2);
                var worker3 = new Worker()
                    {WorkPlace = "Goverment", FirstName = "Vladimir", LastName = "Vladimir", Readers = readers2};
                libraryContex.Workers.Add(worker3);

                var product1 = new Product()
                    {Name = "product1", TypeOfCategory = TypeOfCategory.Story, InStock = true, Library = library1};
                
                var product2 = new Product()
                    {Name = "product2", TypeOfCategory = TypeOfCategory.Textbook, InStock = false, Library = library1};
                
                var product3 = new Product()
                    {Name = "product3", TypeOfCategory = TypeOfCategory.Story, InStock = true, Library = library1};
                

                var author1 = new Author()
                    {Id = product1.Id, FirstName = "Max", LastName = "Max"};
                product1.Author = author1;
                libraryContex.Authors.Add(author1);
                var author2 = new Author()
                    {Id = product2.Id, FirstName = "Alexandr", LastName = "Alexandr"};
                product2.Author = author2;
                libraryContex.Authors.Add(author2);
                var author3 = new Author()
                    {Id = product3.Id, FirstName = "Vasily", LastName = "Vasily"};
                product3.Author = author3;
                libraryContex.Authors.Add(author3);


                var edition1 = new Edition()
                    {Id = product1.Id, Name = "A", TypeOfEdition = TypeOfEdition.Book};
                libraryContex.Editions.Add(edition1);
                var edition2 = new Edition()
                    {Id = product2.Id, Name = "B", TypeOfEdition = TypeOfEdition.Newspaper};
                libraryContex.Editions.Add(edition2);
                var edition3 = new Edition()
                    {Id = product3.Id, Name = "C", TypeOfEdition = TypeOfEdition.Reports};
                libraryContex.Editions.Add(edition3);

                var location1 = new Location()
                    {Id = product1.Id, NumberOfBench = 1, NumberOfHall = 1, NumberOfShelving = 1};
                libraryContex.Locations.Add(location1);
                var location2 = new Location()
                    {Id = product2.Id, NumberOfBench = 2, NumberOfHall = 2, NumberOfShelving = 2};
                libraryContex.Locations.Add(location2);
                var location3 = new Location()
                    {Id = product3.Id, NumberOfBench = 3, NumberOfHall = 3, NumberOfShelving = 3};
                libraryContex.Locations.Add(location3);

                var limit1 = new Limit()
                    {Id = product1.Id, LimitValue = "limitValue1"};
                libraryContex.Limits.Add(limit1);

                var limit2 = new Limit()
                    {Id = product2.Id, LimitValue = "limitValue2"};
                libraryContex.Limits.Add(limit2);

                var limit3 = new Limit()
                    {Id = product3.Id, LimitValue = "limitValue3"};
                libraryContex.Limits.Add(limit3);

                var product4 = new Product()
                    {Name = "product4", TypeOfCategory = TypeOfCategory.Story, InStock = true, Library = library2};
                var product5 = new Product()
                    {Name = "product5", TypeOfCategory = TypeOfCategory.Textbook, InStock = false, Library = library2};
                var product6 = new Product()
                    {Name = "product6", TypeOfCategory = TypeOfCategory.Story, InStock = true, Library = library2};

                var author4 = new Author()
                    {Id = product4.Id, FirstName = "Max", LastName = "Max"};
                libraryContex.Authors.Add(author4);
                var author5 = new Author()
                    {Id = product5.Id, FirstName = "Alexandr", LastName = "Alexandr"};
                libraryContex.Authors.Add(author5);
                var author6 = new Author()
                    {Id = product6.Id, FirstName = "Vasily", LastName = "Vasily"};
                libraryContex.Authors.Add(author6);
                product1.Author = author1;
                product2.Author = author2;
                product3.Author = author3;
                product4.Author = author4;
                product5.Author = author5;
                product6.Author = author6;

                var edition4 = new Edition()
                    {Id = product4.Id, Name = "D", TypeOfEdition = TypeOfEdition.Book};
                product4.Edition = edition4;
                libraryContex.Editions.Add(edition4);
                var edition5 = new Edition()
                    {Id = product5.Id, Name = "E", TypeOfEdition = TypeOfEdition.Newspaper};
                product5.Edition = edition5;
                libraryContex.Editions.Add(edition5);
                var edition6 = new Edition()
                    {Id = product6.Id, Name = "F", TypeOfEdition = TypeOfEdition.Reports};
                product6.Edition = edition6;
                libraryContex.Editions.Add(edition6);

                var location4 = new Location()
                    {Id = product4.Id, NumberOfBench = 1, NumberOfHall = 1, NumberOfShelving = 1};
                product4.Location = location4;
                libraryContex.Locations.Add(location4);
                var location5 = new Location()
                    {Id = product5.Id, NumberOfBench = 2, NumberOfHall = 2, NumberOfShelving = 2};
                product5.Location = location5;
                libraryContex.Locations.Add(location5);
                var location6 = new Location()
                    {Id = product6.Id, NumberOfBench = 3, NumberOfHall = 3, NumberOfShelving = 3};
                product6.Location = location6;
                libraryContex.Locations.Add(location6);

                var limit4 = new Limit()
                    {Id = product4.Id, LimitValue = "limitValue4"};
                product4.Limit = limit4;
                libraryContex.Limits.Add(limit4);
                var limit5 = new Limit()
                    {Id = product5.Id, LimitValue = "limitValue5"};
                product5.Limit = limit5;
                libraryContex.Limits.Add(limit5);
                var limit6 = new Limit()
                    {Id = product6.Id, LimitValue = "limitValue6"};
                product6.Limit = limit6;
                libraryContex.Limits.Add(limit6);

                var issue1 = new Issue()
                {
                    DateOfIssue = new DateTime(2000, 1, 10), DateOfExpiry = new DateTime(2001, 1, 10),
                    Product = product1, Ticket = student1, IsReturned = false, Library = library1
                };
                var issue2 = new Issue()
                {
                    DateOfIssue = new DateTime(2010, 1, 10), DateOfExpiry = new DateTime(2011, 1, 10),
                    Product = product2, Ticket = student2, IsReturned = true, Library = library1
                };
                var issue3 = new Issue()
                {
                    DateOfIssue = new DateTime(2018, 1, 10), DateOfExpiry = new DateTime(2019, 1, 10),
                    Product = product3, Ticket = pensioner1, IsReturned = false, Library = library1
                };


                var issue4 = new Issue()
                {
                    DateOfIssue = new DateTime(2004, 1, 10), DateOfExpiry = new DateTime(2005, 1, 10),
                    Product = product4, Ticket = pensioner2, IsReturned = false, Library = library2
                };
                var issue5 = new Issue()
                {
                    DateOfIssue = new DateTime(2005, 1, 10), DateOfExpiry = new DateTime(2006, 1, 10),
                    Product = product5, Ticket = teacher3, IsReturned = true, Library = library2
                };
                var issue6 = new Issue()
                {
                    DateOfIssue = new DateTime(2006, 1, 10), DateOfExpiry = new DateTime(2007, 1, 10),
                    Product = product6, Ticket = schoolchild2, IsReturned = true, Library = library2
                };
                libraryContex.Products.AddRange(product1,product2,product3,product4,product5,product6);
                libraryContex.Issues.Add(issue6);

                var libraryWorker1 = new LibraryWorker()
                    {FirstName = "Konstantin1", LastName = "Konstantin1", Library = library1};
                libraryContex.LibraryWorkers.Add(libraryWorker1);
                issue1.LibraryWorker = new List<LibraryWorker>() {libraryWorker1};
                var libraryWorker2 = new LibraryWorker()
                    {FirstName = "Konstantin2", LastName = "Konstantin2", Library = library1};
                libraryContex.LibraryWorkers.Add(libraryWorker2);

                issue2.LibraryWorker = new List<LibraryWorker>() {libraryWorker2};
                library1.LibraryWorker = new List<LibraryWorker>() {libraryWorker1, libraryWorker2};
                var libraryWorker3 = new LibraryWorker()
                    {FirstName = "libWorker3", LastName = "libWorker3", Library = library2};
                libraryContex.LibraryWorkers.Add(libraryWorker3);

                issue3.LibraryWorker = new List<LibraryWorker>() {libraryWorker3};
                var libraryWorker4 = new LibraryWorker()
                    {FirstName = "libWorker4", LastName = "libWorker4", Library = library2};
                libraryContex.LibraryWorkers.Add(libraryWorker4);

                issue4.LibraryWorker = new List<LibraryWorker>() {libraryWorker4};
                library2.LibraryWorker = new List<LibraryWorker>() {libraryWorker3, libraryWorker4};
                libraryContex.Issues.AddRange(issue1,issue2,issue3,issue4,issue5,issue6);

                libraryContex.SaveChanges();
            }
        }

        private void PrintSchoolchildByClass(object sender, RoutedEventArgs e)
        {
            var schoolchildByClass = _libraryContextRepository.GetSchoolchildByClass(int.Parse(NumberOfClass.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = schoolchildByClass.Result;
            Result.Content = null;
            Result.Content = "Результат 1 запроса";
        }

        private void PrintWorkerByWorkPlace(object sender, RoutedEventArgs e)
        {
            var workerByWorkPlace = _libraryContextRepository.GetWorkerByWorkPlace(WorkPlace.Text);
            grid.ItemsSource = null;
            grid.ItemsSource = workerByWorkPlace.Result;
            Result.Content = null;
            Result.Content = "Результат 2 запроса";
        }

        private void PrintTeacherByUniversity(object sender, RoutedEventArgs e)
        {
            var teacherByUniversity = _libraryContextRepository.GetTeacherByUniversity(NameOfUniversity.Text);
            grid.ItemsSource = null;
            grid.ItemsSource = teacherByUniversity.Result;
            Result.Content = null;
            Result.Content = "Результат 3 запроса";
        }

        private void PrintPensionerByNumberOfPensionDocument(object sender, RoutedEventArgs e)
        {
            var pensionerByNumberOfPensionDocument = _libraryContextRepository.GetPensionerByNumberOfPensionDocument(
                int.Parse(NumberOfPensionDocument.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = new List<Pensioner>() {pensionerByNumberOfPensionDocument.Result};
            Result.Content = null;
            Result.Content = "Результат 4 запроса";
        }

        private void PrintStudentByUniversity(object sender, RoutedEventArgs e)
        {
            var studentByUniversity = _libraryContextRepository.GetStudentByUniversity(NameOfUniversityByStudent.Text);
            grid.ItemsSource = null;
            grid.ItemsSource = studentByUniversity.Result;
            Result.Content = null;
            Result.Content = "Результат 5 запроса";
        }

        private void PrintPeopleByReadingProduct(object sender, RoutedEventArgs e)
        {
            var peopleByReadingProduct = _libraryContextRepository.GetPeopleByReadingProduct(NameOfBook.Text);
            grid.ItemsSource = null;
            if (peopleByReadingProduct != null)
            {
                grid.ItemsSource = peopleByReadingProduct.Result;
            }

            Result.Content = null;
            Result.Content = "Результат 6 запроса";
        }

        private void PrintPeopleByReadingProductOnTime(object sender, RoutedEventArgs e)
        {
            DateTime startDay;
            DateTime finishDay;
            var startDayIsParsed = DateTime.TryParse(datePicker1.SelectedDate.ToString(), out startDay);
            var finishDayIsParsed = DateTime.TryParse(datePicker2.SelectedDate.ToString(), out finishDay);

            if (startDayIsParsed && finishDayIsParsed)
            {
                var peopleByReadingProductOnTime = _libraryContextRepository.GetPeopleByReadingProductOnTime(
                    startDay,
                    finishDay);
                grid.ItemsSource = null;
                grid.ItemsSource = peopleByReadingProductOnTime.Result;
                Result.Content = null;
                Result.Content = "Результат 7 запроса";
            }
        }

        private void PrintMostPopularProduct(object sender, RoutedEventArgs e)
        {
            var popularProduct = _libraryContextRepository.GetMostPopularProduct();
            grid.ItemsSource = null;
            grid.ItemsSource = new List<Product> {popularProduct.Result};
            Result.Content = null;
            Result.Content = "Результат 8 запроса";
        }

        private void PrintWorkerLibraryByLibrary(object sender, RoutedEventArgs e)
        {
            var workerLibraryByLibrary = _libraryContextRepository.GetWorkerLibraryByLibrary(int.Parse(IdLibrary.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = workerLibraryByLibrary.Result;
            Result.Content = null;
            Result.Content = "Результат 9 запроса";
        }

        private void PrintOverdueReader(object sender, RoutedEventArgs e)
        {
            var overdueReader = _libraryContextRepository.GetOverdueReader();
            grid.ItemsSource = null;
            grid.ItemsSource = overdueReader.Result;
            Result.Content = null;
            Result.Content = "Результат 10 запроса";
        }

        private void PrintProductByLocation(object sender, RoutedEventArgs routedEventArgs)
        {
            var productByLocation = _libraryContextRepository.GetProductByLocation(int.Parse(NumberOfShelving.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = productByLocation.Result;
            Result.Content = null;
            Result.Content = "Результат 11 запроса";
        }

        private void PrintPeopleServicedByLibraryWorker(object sender, RoutedEventArgs e)
        {
            var servicedByLibraryWorker =
                _libraryContextRepository.GetPeopleServicedByLibraryWorker(int.Parse(LibraryWorkerId.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = servicedByLibraryWorker.Result;
            Result.Content = null;
            Result.Content = "Результат 12 запроса";
        }

        private void PrintProductByAuthor(object sender, RoutedEventArgs e)
        {
            var product = _libraryContextRepository.GetProductByAuthor(int.Parse(AuthorId.Text));
            grid.ItemsSource = null;
            grid.ItemsSource = product.Result;
            Result.Content = null;
            Result.Content = "Результат 13 запроса";
        }

        private void PrintCountPeopleServicedByLibraryWorker(object sender, RoutedEventArgs e)
        {
            DateTime startDay;
            DateTime finishDay;
            var startDayIsParsed = DateTime.TryParse(datePicker3.SelectedDate.ToString(), out startDay);
            var finishDayIsParsed = DateTime.TryParse(datePicker4.SelectedDate.ToString(), out finishDay);

            if (startDayIsParsed && finishDayIsParsed)
            {
                var countPeople = _libraryContextRepository.GetPeopleByReadingProductOnTime(
                    startDay,
                    finishDay);
                grid.ItemsSource = null;
                grid.ItemsSource = countPeople.Result;
                Result.Content = null;
                Result.Content = "Результат 14 запроса";
            }
        }

        private void ShowTickets(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddReader();
            newWindow.Show();
        }
    }
}