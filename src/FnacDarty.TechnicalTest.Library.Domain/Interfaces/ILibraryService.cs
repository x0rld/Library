using FnacDarty.TechnicalTest.Library.Domain.Entities;
using FnacDarty.TechnicalTest.Library.Models;

namespace FnacDarty.TechnicalTest.Library.Domain.Interfaces
{
    public interface ILibraryService
    {
        void AddBook(string title, string author);

        IReadOnlyCollection<Book> GetAllBooks();
        
        BorrowedBookResult BorrowBooks(int customerId, IReadOnlyCollection<int> bookIds);
    }
}