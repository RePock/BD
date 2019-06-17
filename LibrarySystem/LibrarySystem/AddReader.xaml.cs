using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LibrarySystem.Models;
using LibrarySystem.Models.Repository;

namespace LibrarySystem
{
    public partial class AddReader : Window
    {
        private LibraryContextRepository _libraryContextRepository;

        public AddReader()
        {
            _libraryContextRepository = new LibraryContextRepository();
            InitializeComponent();
        }

        private void AddTicket(object sender, RoutedEventArgs e)
        {
            if (FirstName != null && SecondName != null)
            {
                _libraryContextRepository.CreateTicket(FirstName.Text, SecondName.Text, int.Parse(ReadersId.Text));
                PrintAllReaders(sender, e);
            }
        }

        private void PrintAllReaders(object sender, RoutedEventArgs e)
        {
            var readers = _libraryContextRepository.GetAllTicket();
            Grid.ItemsSource = null;
            Grid.ItemsSource = readers.Result;
        }

        private void RemoteTicket(object sender, RoutedEventArgs e)
        {
            _libraryContextRepository.DeleteTicket(int.Parse(TicketId.Text));
            PrintAllReaders(sender, e);
        }

        private void Grid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var rowIndex = e.Row.GetIndex();
            var column = e.Column.DisplayIndex;
            if (column == 1 || column == 2)
            {
                var value = ((TextBox) e.EditingElement).Text;
                var ticket = Grid.Items[rowIndex] as Ticket;
                if (column == 1)
                {
                    _libraryContextRepository.ChangeTicket(ticket.Id, value, ticket.LastName, ticket.ReadersId);
                    return;
                }

                _libraryContextRepository.ChangeTicket(ticket.Id, ticket.FirstName, value, ticket.ReadersId);
                return;
            }

            if (column == 3)
            {
                var value = int.Parse(((TextBox) e.EditingElement).Text);
                var ticket = Grid.Items[rowIndex] as Ticket;
                _libraryContextRepository.ChangeTicket(ticket.Id, ticket.FirstName, ticket.LastName, value);
            }
        }
    }
}